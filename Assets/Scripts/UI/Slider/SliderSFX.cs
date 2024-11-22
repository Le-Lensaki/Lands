using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderSFX : SliderBase
{
    protected override void OnChanged(float valueChanged)
    {
        AudioManager.Instance.VolumeSetting.SetSFXVolume(valueChanged);
    }
}
