using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class BaseButton : LensakiMonoBehaviour 
{
    [SerializeField] protected Button button;
    [SerializeField] protected Sprite pressSprite;
    [SerializeField] protected Sprite defaultSprite;

    protected override void Start()
    {
        base.Start();
        AddOnClickEvent();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
    }
    

    protected void AddOnClickEvent()
    {
        this.button.onClick.AddListener(this.OnClick);
    }

    protected abstract void OnClick();
   
}
