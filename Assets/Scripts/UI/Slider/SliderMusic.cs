using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderMusic : SliderBase
{
    protected override void OnChanged(float valueChanged)
    {
        AudioManager.Instance.VolumeSetting.SetMusicVolume(valueChanged);
    }
}
