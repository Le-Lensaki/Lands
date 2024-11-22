using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class SliderHPCanvas : LensakiMonoBehaviour
{
    [SerializeField] protected Canvas canvas;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCanvas();
    }

    protected virtual void LoadCanvas()
    {
        if (canvas != null) return;

        canvas = GetComponent<Canvas>();
        canvas.renderMode = RenderMode.WorldSpace;
        canvas.worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();

        Debug.Log(transform.name + ": LoadCanvas", gameObject);
    }
}
