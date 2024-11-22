using Assets.Scripts.Item.IDItem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] protected IDItem idItemSlot;

    public IDItem IDItemSlot { get { return idItemSlot; }  }


    public void SetIDItemSlot(IDItem idItem)
    {
        this.idItemSlot = idItem;
    }

}
