using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : LensakiMonoBehaviour where T : Singleton<T>
{
    private static T instance;
    public static T Instance
    {
        get { return instance; }
    }

    protected override void Awake()
    {
        base.Awake();

        if (instance != null) Debug.LogError("Only 1 "+ transform.name + " instance allow to exist");

        instance = this as T;
        //DontDestroyOnLoad(this.gameObject);
    }

}
