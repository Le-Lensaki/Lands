using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : LensakiMonoBehaviour
{
    public float destrucTime;
    private float timer;

    protected override void OnEnable()
    {
        base.OnEnable();
        timer = destrucTime;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            SpawnerManager.Instance.GetSpawner<TextLootSpawner>().Despawn(transform);
        }
    }
}
