using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpCommand : Command
{
    private GameActor actor;

    public MoveUpCommand(GameActor actor)
    {
        this.actor = actor;
    }

    public override void Execute()
    {
        actor.MoveUp();
    }

    public override void Undo()
    {
        actor.MoveDown();
    }
}
