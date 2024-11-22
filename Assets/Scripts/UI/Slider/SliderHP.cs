using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderHP : SliderBase
{
    [SerializeField] protected float maxHP = 100;
    [SerializeField] protected float currentHP = 70;

    private void FixedUpdate()
    {
        this.HPShowing();
    }

    protected virtual void HPShowing()
    {
        float hpPercent = currentHP/ maxHP;
        this.slider.value = hpPercent;
    }

    protected override void OnChanged(float valueChanged)
    {
        
    }

    public virtual void SetMaxHP(float maxHP)
    {
        this.maxHP = maxHP;
    }
    public virtual void SetCurrentHP(float currentHP)
    {
        this.currentHP = currentHP;
    }
}
