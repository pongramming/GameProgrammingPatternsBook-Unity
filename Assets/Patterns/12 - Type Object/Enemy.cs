using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The book gave an alternative without inheritance,
//where each creature would be an instance of Enemy with a reference to their correspondent type class.
//But I thing the combination of Inheritance + ScriptableObject works really nice here.
public abstract class Enemy : ScriptableObject
{
    [SerializeField] protected string enemyName;
    [SerializeField] protected string attackPhrase;
    [SerializeField] protected int damage;

    public abstract void Attack();
}
