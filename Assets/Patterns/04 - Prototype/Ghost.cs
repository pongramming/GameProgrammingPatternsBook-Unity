using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Monster
{
    private static int ghostCounter = 0;

    public Ghost(int health, int speed)
    {
        this.health = health;
        this.speed = speed;

        ghostCounter++;
    }

    public override Monster Clone()
    {
        return new Ghost(health, speed);
    }

    public override void DoMonstruousThing()
    {
        Debug.Log($"Doing something a Ghost would do... This is the ghost number {ghostCounter}");
    }
}
