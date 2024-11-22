using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LensakiMonoBehaviour : MonoBehaviour
{
    protected virtual void Reset()
    {
        this.LoadComponents();
        this.ResetValue();
    }

    protected virtual void Start()
    {
        
    }

    protected virtual void Awake()
    {
        this.LoadComponents();
    }

    protected virtual void ResetValue()
    {
        
    }

    protected virtual void OnDisable()
    {
        this.ResetValue();
    }

    protected virtual void OnEnable()
    {
        this.ResetValue();
    }
    protected virtual void LoadComponents()
    {

    }

    protected void LoadComponent<T>(ref T component) where T : Component
    {
        if (component != null) return;
        component = this.GetComponent<T>();

        if (component != null)
        {
            //Debug.Log(transform.name + ": Loaded " + typeof(T).Name, gameObject);
        }
        else
        {
            //Debug.LogWarning(transform.name + ": " + typeof(T).Name + " not found", gameObject);
        }
    }


    public virtual void LoadGameObjectByName(ref GameObject elementObject, string nameGameObject)
    {
        if (elementObject != null) return;

        elementObject = GameObject.Find(nameGameObject);

        if (elementObject != null)
        {
            Debug.Log(transform.name + ": Load " + nameGameObject, base.gameObject);
        }
        else
        {
            Debug.LogWarning("GameObject '" + nameGameObject + "' not found", base.gameObject);
        }
    }


    public virtual void AddListGameObjectOfManager(ref List<GameObject> listElementObject, ref GameObject elementObject)
    {
        if (elementObject == null) return;
        if (listElementObject.Contains(elementObject)) return;
        listElementObject.Add(elementObject);

    }    
}
