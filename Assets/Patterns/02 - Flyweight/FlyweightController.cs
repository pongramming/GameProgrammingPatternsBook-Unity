using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controller used to illustrate the Flyweight pattern
//Switch between Heavy and Flyweight and see its effects on Profiler's Memory menu
public class FlyweightController : MonoBehaviour
{
    [SerializeField] private ObjectType objectType;

    [SerializeField] private SharedDataSO sharedData;

    [SerializeField] private int numberOfObjects = 1000000;

    private List<Heavy> heavyObjects = new List<Heavy>();

    private List<Flyweight> flyweightObjects = new List<Flyweight>();

    private void Start()
    {
        switch (objectType)
        {
            case ObjectType.FlyweightObject:
                CreateFlyweightObjects();
                break;
            case ObjectType.HeavyObject:
                CreateHeavyObjects();
                break;
        }
    }

    private void CreateHeavyObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            Heavy newHeavy = new Heavy();

            heavyObjects.Add(newHeavy);
        }
    }

    private void CreateFlyweightObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            Flyweight newFlyweight = new Flyweight(sharedData);

            flyweightObjects.Add(newFlyweight);
        }
    }

    public enum ObjectType
    {
        HeavyObject,
        FlyweightObject
    }
}
