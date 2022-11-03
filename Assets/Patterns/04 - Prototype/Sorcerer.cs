using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorcerer : Monster
{
    private static int sorcererCounter = 0;

    public Sorcerer(int health, int speed)
    {
        this.health = health;
        this.speed = speed;

        sorcererCounter++;
    }

    public override Monster Clone()
    {
        return new Sorcerer(health, speed);
    }

    public override void DoMonstruousThing()
    {
        Debug.Log($"Doing something a Sorcerer would do... This is the sorcerer number {sorcererCounter}");
    }
}
