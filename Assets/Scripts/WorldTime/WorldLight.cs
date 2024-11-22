using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Light2D))]
public class WorldLight : LensakiMonoBehaviour
{
    private Light2D lightWorld;

    [SerializeField] private WorldTime worldTime;

    [SerializeField] private Gradient gradient;

    protected override void Awake()
    {
        base.Awake();
       
        worldTime.WorldTimeChanged += OnWorldTimeChanged;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLightWorld();
    }

    protected virtual void LoadLightWorld()
    {
        if (lightWorld != null) return;
        lightWorld = GetComponent<Light2D>();

        Debug.Log(transform.name + ": LoadLightWorld", gameObject);
    }

    private void OnDestroy()
    {
        worldTime.WorldTimeChanged -= OnWorldTimeChanged;
    }

    private void OnWorldTimeChanged(object sender, TimeSpan newTime)
    {
        lightWorld.color = gradient.Evaluate(PercentOfDay(newTime));
    }

    private float PercentOfDay(TimeSpan timeSpan)
    {
        return (float) timeSpan.TotalMinutes % WorldTimeConstants.MinutesInDay / WorldTimeConstants.MinutesInDay;
    }
}
