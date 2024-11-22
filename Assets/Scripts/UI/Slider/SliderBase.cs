using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public abstract class SliderBase : LensakiMonoBehaviour
{
    [SerializeField] protected Slider slider;
    [SerializeField] public Slider Slider => slider;

    protected override void Start()
    {
        base.Start();
        this.AddOnValueChanged();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSlider();
        
    }

    protected virtual void LoadSlider()
    {
        if (slider != null) return;
        slider = GetComponent<Slider>();
        Debug.Log(transform.name + ": LoadSlider", gameObject);

    }

    protected void AddOnValueChanged()
    {
        this.slider.onValueChanged.AddListener(this.OnChanged);
    }

    protected abstract void OnChanged(float valueChanged);



}
