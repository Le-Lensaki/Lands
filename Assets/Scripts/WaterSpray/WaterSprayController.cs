using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSprayController : LensakiMonoBehaviour
{
    protected static WaterSprayController instance;
    public static WaterSprayController Instance { get { return instance; } }

    [SerializeField] protected WaterSprayAnimation anim;

    protected override void Awake()
    {
        base.Awake();
        if (WaterSprayController.instance != null) Debug.LogError("Only 1 WaterSprayController allow to exist");
        WaterSprayController.instance = this;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimation();
    }

    protected virtual void LoadAnimation()
    {
        if (anim != null) return;
        this.anim = GetComponent<WaterSprayAnimation>();

        Debug.Log(transform.name + ": LoadAction", gameObject);
    }

    public void Spray(Vector2 vectorSpray)
    {
        anim.Spray(vectorSpray);
    }
}
