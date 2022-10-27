using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftCommand : Command
{
    private GameActor actor;

    public MoveLeftCommand(GameActor actor)
    {
        this.actor = actor;
    }

    public override void Execute()
    {
        actor.MoveLeft();
    }

    public override void Undo()
    {
        actor.MoveRight();
    }
}
