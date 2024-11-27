using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTime : Singleton<WorldTime>
{

    public event EventHandler<TimeSpan> WorldTimeChanged;

    [SerializeField] private float dayLength; //in seconds
    [SerializeField] private int dayCount;
    public int CurrentDay => dayCount;

    private TimeSpan currentWorldTime = wakeUP;

    protected static TimeSpan wakeUP = TimeSpan.FromHours(6);
    private float minuteLength => dayLength / WorldTimeConstants.MinutesInDay;

    private Coroutine worldTimeCoroutine;
    private bool isWorldTimeRunning = false;

    public double GetWorldTime()
    {
        return currentWorldTime.TotalMilliseconds;
    }
    public void SetWorldTime(double milliseconds)
    {
        currentWorldTime = TimeSpan.FromMilliseconds(milliseconds);
    }

    private IEnumerator AddMinute()
    {
        while (isWorldTimeRunning)
        {
            int hour = Convert.ToInt32(currentWorldTime.TotalHours);
            dayCount = hour / 24;

            currentWorldTime += TimeSpan.FromMinutes(1f);
            WorldTimeChanged?.Invoke(this, currentWorldTime);

            yield return new WaitForSeconds(minuteLength);
        }
    }
    public void PlayWorldTime()
    {
        if (!isWorldTimeRunning)
        {
            isWorldTimeRunning = true;
            worldTimeCoroutine = StartCoroutine(AddMinute());
        }
    }

    public void StopWorldTime()
    {
        isWorldTimeRunning = false;
        if (worldTimeCoroutine != null)
        {
            StopCoroutine(worldTimeCoroutine);
            worldTimeCoroutine = null;
        }
    }
    public void WakeUP()
    {
        TimeSpan timeElapsedToday = currentWorldTime - TimeSpan.FromHours(currentWorldTime.TotalHours % 24);
        currentWorldTime = timeElapsedToday + TimeSpan.FromHours(6)+TimeSpan.FromDays(1);
    }
}