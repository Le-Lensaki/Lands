using Assets.Scripts.Item.IDItem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassController : ObjectController
{
    protected override void Start()
    {
        base.Start();
        idItemAction = IDItem.Hoe;
    }


    protected override void LoadComponents()
    {
        base.LoadComponents();
        
    }
}
