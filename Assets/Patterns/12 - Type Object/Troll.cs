using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Patterns/Type Object/Troll")]
public class Troll : Enemy
{
    public override void Attack()
    {
        Debug.Log(attackPhrase);
    }
}
