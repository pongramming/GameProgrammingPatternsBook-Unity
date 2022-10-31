using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyweight
{
    //Data for each individual object
    private float damage;

    //Data being shared between all objects
    private SharedDataSO data;

    public Flyweight(SharedDataSO data)
    {
        damage = Random.Range(13f, 130f);

        this.data = data;
    }
}
