using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDownCommand : Command
{
    private GameActor actor;

    public MoveDownCommand(GameActor actor)
    {
        this.actor = actor;
    }

    public override void Execute()
    {
        actor.MoveDown();
    }

    public override void Undo()
    {
        actor.MoveUp();
    }
}
