using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRightCommand : Command
{
    private GameActor actor;

    public MoveRightCommand(GameActor actor)
    {
        this.actor = actor;
    }

    public override void Execute()
    {
        actor.MoveRight();
    }

    public override void Undo()
    {
        actor.MoveLeft();
    }
}
