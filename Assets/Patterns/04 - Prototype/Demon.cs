using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : Monster
{
    private static int demonCounter = 0;

    public Demon(int health, int speed)
    {
        this.health = health;
        this.speed = speed;

        demonCounter++;
    }

    public override Monster Clone()
    {
        return new Demon(health, speed);
    }

    public override void DoMonstruousThing()
    {
        Debug.Log($"Doing something a Demon would do... This is the demon number {demonCounter}");
    }
}
