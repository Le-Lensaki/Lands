using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class WorldTimeDisplay : MonoBehaviour
{
    [SerializeField] private WorldTime worldTime;
    [SerializeField] private TMP_Text countDay;

    private TMP_Text time;

    private void Awake()
    {
        time = GetComponent<TMP_Text>();
        worldTime.WorldTimeChanged += OnWorldTimeChanged;
        
    }

    private void OnDestroy()
    {
        worldTime.WorldTimeChanged -= OnWorldTimeChanged;
    }

    private void OnWorldTimeChanged(object sender, TimeSpan newTime)
    {
        time.SetText(newTime.ToString(@"hh\:mm"));
        countDay.text = "Day " + worldTime.CurrentDay;
    }
}
