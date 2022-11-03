using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    private Ghost ghostPrototype;
    private Demon demonPrototype;
    private Sorcerer sorcererPrototype;

    private Spawner[] monsterSpawners;

    private void Start()
    {
        //Starting with one of each monster, that will be used as the prototype
        ghostPrototype = new Ghost(4, 20);
        demonPrototype = new Demon(30, 24);
        sorcererPrototype = new Sorcerer(2, 10);

        monsterSpawners = new Spawner[]
        {
            new Spawner(ghostPrototype),
            new Spawner(demonPrototype),
            new Spawner(sorcererPrototype)
        };
    }

    public void SpawnRandomMonster()
    {
        Spawner randomSpawner = monsterSpawners[Random.Range(0, monsterSpawners.Length)];

        Monster randomMonster = randomSpawner.SpawnMonster();

        randomMonster.DoMonstruousThing();
    }
}
