using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderVolumeAll : SliderBase
{
    protected override void OnChanged(float valueChanged)
    {
        AudioManager.Instance.VolumeSetting.SetALLVolume(valueChanged);
    }
}
