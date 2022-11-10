using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyLaunch : Superpower
{
    public override void Activate()
    {
        if (true) //Just to show that you can do some control flow in the Activate method
        {
            Move(new Vector2(0f, 2f));
            SpawnParticles("Fire");
            GetSoundPlayer().PlaySound("Sky Launch");
        }
        else
        {
            //Do some other things...
        }
    }
}
