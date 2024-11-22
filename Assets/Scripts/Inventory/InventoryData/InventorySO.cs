using Assets.Scripts.Item.IDItem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "SO/Inventory")]
public class InventorySO : ScriptableObject
{
    [field: SerializeField] private List<InventoryItem> inventoryItems;

    [field: SerializeField] public int Size { get; private set; } = 120;

    public void Initialize(List<InventoryItem> inventoryItems)
    {
        if(inventoryItems == null)
        {
            this.inventoryItems = new List<InventoryItem>();
            for (int i = 0; i < Size; i++)
            {
                this.inventoryItems.Add(InventoryItem.GetEmptyItem());
            }
        }
        else
        {
            this.inventoryItems = inventoryItems;
        }
        
    }

    public void AddItem(Item item, int quatity)
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {

            if (!inventoryItems[i].IsEmpty && inventoryItems[i].item.GetName == item.GetName)
            {
                inventoryItems[i] = inventoryItems[i].ChangeQuatity(inventoryItems[i].quatity + quatity);
                return; 
            }
        }

        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].IsEmpty)
            {
                inventoryItems[i] = new InventoryItem
                {
                    item = item,
                    quatity = quatity
                };
                return;
            }
        }
    }

    public bool RemoveItem(Item item, int quantity)
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].IsEmpty) return false;
            if (item == null) return false;
            if(inventoryItems[i].item.GetName == item.GetName)
            {
                int newQuantity = inventoryItems[i].quatity - quantity;

                if (newQuantity > 0)
                {
                    inventoryItems[i] = inventoryItems[i].ChangeQuatity(newQuantity);
                    return true;
                }
                else 
                {
                   
                    inventoryItems[i] = new InventoryItem();
                    if (newQuantity == 0) return true;
                    
                    return false;
                }
                
            }
        }
        return false;
    }


    public void ChangeIndexItem(IDItem idItemBefore, IDItem idItemAfter)
    {
        if (idItemBefore == IDItem.NoItem || idItemAfter == IDItem.NoItem) return;

        ChangeItem(inventoryItems.Find(x => x.item.GetId == idItemBefore), inventoryItems.Find(x => x.item.GetId == idItemAfter));
    }
    
    protected virtual void ChangeItem(InventoryItem itemBefore, InventoryItem itemAfter)
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].IsEmpty) continue;

            if (inventoryItems[i].item.GetId == itemBefore.item.GetId)
            {
                inventoryItems[i] = itemAfter;

                continue;
            }
            if (inventoryItems[i].item.GetId == itemAfter.item.GetId)
            {
                inventoryItems[i] = itemBefore;

                continue;
            }

        }
    }

    public InventoryItem GetInventoryItem(IDItem idItem)
    {
        foreach (var item in inventoryItems)
        {
            if(item.item.GetId == idItem)
            {
                return item;
            }    

        }
        return InventoryItem.GetEmptyItem();
    }

    //public List<Item> GetListItemHaveMaterials()
    //{
    //    List<Item> items = new List<Item>();

    //    foreach (var inventoryItem in inventoryItems)
    //    {
    //        if(inventoryItem.item.MaterialProduct.Count > 0)
    //            items.Add(inventoryItem.item);
    //    }


    //    return items;
    //}
    

    public Dictionary<int, InventoryItem> GetCurrentInventoryState()
    {
        Dictionary<int, InventoryItem> returnValue = new Dictionary<int, InventoryItem>();
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].IsEmpty)
                continue;
            returnValue[i] = inventoryItems[i];
        }
        return returnValue;
    }    

}
