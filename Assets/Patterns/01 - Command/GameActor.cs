using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameActor : MonoBehaviour
{
    private const float MOVE_STEP_DISTANCE = 1f;

    public void MoveUp()
    {
        Move(Vector2.up);
    }

    public void MoveDown()
    {
        Move(Vector2.down);
    }

    public void MoveLeft()
    {
        Move(Vector2.left);
    }

    public void MoveRight()
    {
        Move(Vector2.right);
    }

    private void Move(Vector2 direction)
    {
        transform.Translate(direction * MOVE_STEP_DISTANCE);
    }
}
