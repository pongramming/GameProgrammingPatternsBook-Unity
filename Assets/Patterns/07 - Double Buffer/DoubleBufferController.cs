using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Implementation example from https://github.com/Habrador/Unity-Programming-Patterns/blob/master/Assets/Patterns/7.%20Double%20Buffer/Cave/GameController.cs
//and https://www.youtube.com/watch?v=v7yyZZjF1z4 
//I tought it was so cool that I had to put it here
public class DoubleBufferController : MonoBehaviour
{
    [SerializeField] private MeshRenderer displayPlaneRenderer;

    [Range(0, 1)]
    public float randomFillPercent;

    private int[,] bufferOld;
    private int[,] bufferNew;

    private const int GRID_SIZE = 100;

    private const int SIMULATION_STEPS = 20;

    private float PAUSE_TIME = 1f;

    private void Start()
    {
        bufferOld = new int[GRID_SIZE, GRID_SIZE];
        bufferNew = new int[GRID_SIZE, GRID_SIZE];

        //A seed to get the same random numbers each time we run the script
        Random.InitState(100);

        for(int x = 0; x < GRID_SIZE; x++)
        {
            for(int y = 0; y < GRID_SIZE; y++)
            {
                //The borders will always be a wall
                if (x == 0 || x == GRID_SIZE - 1 || y == 0 || y == GRID_SIZE - 1)
                {
                    bufferOld[x, y] = 1;
                }
                else
                {
                    bufferOld[x, y] = Random.Range(0f, 1f) < randomFillPercent ? 1 : 0;
                }
            }
        }

        StartCoroutine(SimulateCavePattern());
    }

    private IEnumerator SimulateCavePattern()
    {
        for(int i = 0; i < SIMULATION_STEPS; i++)
        {
            RunCellularAutomataStep();

            GenerateAndDisplayTexture(bufferNew);

            (bufferOld, bufferNew) = (bufferNew, bufferOld);

            yield return new WaitForSeconds(PAUSE_TIME);
        }

        Debug.Log("Simulation completed!");
    }

    private void RunCellularAutomataStep()
    {
        for (int x = 0; x < GRID_SIZE; x++)
        {
            for (int y = 0; y < GRID_SIZE; y++)
            {
                //The borders will always be a wall
                if (x == 0 || x == GRID_SIZE - 1 || y == 0 || y == GRID_SIZE - 1)
                {
                    bufferNew[x, y] = 1;

                    continue;
                }

                int surroundingWalls = GetSurroundingWallCount(x, y);

                if (surroundingWalls > 4)
                {
                    bufferNew[x, y] = 1;
                }
                else if (surroundingWalls == 4)
                {
                    bufferNew[x, y] = bufferOld[x, y];
                }
                else
                {
                    bufferNew[x, y] = 0;
                }
            }
        }
    }

    private int GetSurroundingWallCount(int cellX, int cellY)
    {
        int wallCounter = 0;

        for (int neighborX = cellX - 1; neighborX <= cellX + 1; neighborX++)
        {
            for (int neighborY = cellY - 1; neighborY <= cellY + 1; neighborY++)
            {
                if (neighborX == cellX && neighborY == cellY)
                {
                    continue;
                }

                if (bufferOld[neighborX, neighborY] == 1)
                {
                    wallCounter += 1;
                }
            }
        }

        return wallCounter;
    }

    private void GenerateAndDisplayTexture(int[,] data)
    {
        //We are constantly creating new textures, so we have to delete old textures or the memory will keep increasing
        //The garbage collector is not collecting unused textures
        Resources.UnloadUnusedAssets();

        Texture2D texture = new Texture2D(GRID_SIZE, GRID_SIZE);

        texture.filterMode = FilterMode.Point;

        Color[] textureColors = new Color[GRID_SIZE * GRID_SIZE];

        for (int y = 0; y < GRID_SIZE; y++)
        {
            for (int x = 0; x < GRID_SIZE; x++)
            {
                textureColors[y * GRID_SIZE + x] = data[x, y] == 1 ? Color.black : Color.white;
            }
        }

        texture.SetPixels(textureColors);

        texture.Apply();

        displayPlaneRenderer.sharedMaterial.mainTexture = texture;
    }
}
