using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameActor actor;

    private Command buttonW;
    private Command buttonA;
    private Command buttonS;
    private Command buttonD;

    private List<Command> commandsList = new List<Command>();
    private int currentCommandIndex = -1;

    private void Start()
    {
        buttonW = new MoveUpCommand(actor);
        buttonA = new MoveLeftCommand(actor);
        buttonS = new MoveDownCommand(actor);
        buttonD = new MoveRightCommand(actor);
    }

    private void Update()
    {
        //A reified call - Delaying execution
        Command inputCommand = HandleInput();

        //doing any needed logic...

        //Execute command
        ExecuteCommand(inputCommand);
    }

    private Command HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            return buttonW;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            return buttonA;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            return buttonS;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            return buttonD;
        }

        return null;
    }

    private void ExecuteCommand(Command command)
    {
        if(command != null)
        {
            if(commandsList.Count > currentCommandIndex + 1)
            {
                for(int i = commandsList.Count - 1; i > currentCommandIndex; i--)
                {
                    commandsList.RemoveAt(i);
                }
            }

            command.Execute();
            commandsList.Add(command);
            currentCommandIndex++;
        }
            
    }

    private void SwapKeys(ref Command key1, ref Command key2)
    {
        Command temp = key1;

        key1 = key2;

        key2 = temp;
    }

    public void SwapAandDKeysButton()
    {
        //ref is important or the keys will not be swapped
        SwapKeys(ref buttonA, ref buttonD);
    }

    public void UndoCommandButton()
    {
        if(currentCommandIndex == -1)
        {
            Debug.Log("Current command is the first one.");
        }
        else
        {
            commandsList[currentCommandIndex].Undo();
            currentCommandIndex--;
        }
    }

    public void RedoCommandButton()
    {
        if (currentCommandIndex == commandsList.Count - 1)
        {
            Debug.Log("Current command is the last one.");
        }
        else
        {
            currentCommandIndex++;
            commandsList[currentCommandIndex].Execute();
        }
    }
}
