using Assets.Scripts.Item.IDItem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct InventoryItem
{
    public Item item;
    public int quatity;

    public bool IsEmpty => item == null;

    public InventoryItem ChangeQuatity(int newQuantity)
    {
        if(!IsItemRunOut(newQuantity))
        {
            return new InventoryItem
            {
                item = this.item,
                quatity = newQuantity,
            };
        }
        return InventoryItem.GetEmptyItem();

    }

    bool IsItemRunOut(int newQuantity)
    {
        if (newQuantity <= 0) return true;
        return false;
    }

    public InventoryItem ChangeInventoryItem(InventoryItem inventoryItem)
    {
        return new InventoryItem
        {
            item = inventoryItem.item,
            quatity = inventoryItem.quatity,
        };
    }

    public static InventoryItem GetEmptyItem() => new InventoryItem
    {
        item = null,
        quatity = 0,
    };
}
