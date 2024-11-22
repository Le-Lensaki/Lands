using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : Singleton<SpawnerManager>
{
    [SerializeField] List<Spawner> listSpawner;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadListSpawner();
    }
    #region LoadComponents
    protected virtual void LoadListSpawner()
    {
        if (listSpawner.Count > 0) return;

        for (int i = 0; i < transform.childCount; i++)
        {
            listSpawner.Add(transform.GetChild(i).GetComponent<Spawner>());
        }    
    }
    #endregion


    public T GetSpawner<T>() where T : Spawner
    {
        foreach (var spawner in listSpawner)
        {
            if (spawner is T) 
            {
                return spawner as T;
            }
        }
        return null;
    }
}
