using Assets.Scripts.Item.IDItem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneController : ObjectController
{

    [SerializeField] protected StoneAnimation anim;

    protected override void Start()
    {
        base.Start();
        idItemAction = IDItem.Hoe;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadComponent(ref anim);
    }

    public override void Action()
    { 
    
    }

}
