using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ItemPickable : LensakiMonoBehaviour
{
    [SerializeField] protected Collider2D colliderItem;

    [SerializeField] protected Item item;

    public Item GetItem => item;

    protected float delay = 0;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTrigger();
    }

    protected virtual void LoadTrigger()
    {
        if (colliderItem != null) return;
        this.colliderItem = transform.GetComponent<BoxCollider2D>();
        this.colliderItem.isTrigger = true;

        Debug.Log(transform.name + ": LoadTrigger", gameObject);
    }

    public virtual void LootItem()
    {
        InventoryController.Instance.AddItem(item);
    }


}
