using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Patterns/Type Object/Dragon")]
public class Dragon : Enemy
{
    public override void Attack()
    {
        Debug.Log(attackPhrase);
    }
}
