using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T>: MonoBehaviour where T : Singleton<T>
{
    private static T instance;

    public static T Instance
    {
        get { return instance; }
    }

    public static bool IsIntialized
    {
        get { return instance != null; }
    }


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("[Singleton]: Trying to instantiate a second instance of singleton class");
        }
        else
        {
            instance = (T)this; //casting to type T
        }
    }

    protected virtual void OnDestroy()
    {
        //if object is destroyed make other instance null so it can be reset
        if(instance == this)
        {
            instance = null; //made to null so another object can be created
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
