using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class doesn't share any data among all objects
public class Heavy
{
    private float damage;

    private Data data;


    public Heavy()
    {
        damage = Random.Range(13f, 130f);

        data = new Data();
    }
}