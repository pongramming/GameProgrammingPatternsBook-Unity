using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// I decided to keep this implementation of the Singleton pattern really simple,
// since this chapter wasn't about how to use Singleton, but how NOT to use it.
//
public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject singletonObject = new GameObject();
                singletonObject.name = typeof(T).Name + " Singleton Object";
                _instance = singletonObject.AddComponent<T>();
            }
            return _instance;
        }
    }

    public virtual void Awake()
    {
        if(Instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if(_instance == this)
        {
            _instance = null;
        }
    }
}
