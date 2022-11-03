using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster
{
    public int health;
    public int speed;

    public abstract Monster Clone();
    public abstract void DoMonstruousThing();
}
