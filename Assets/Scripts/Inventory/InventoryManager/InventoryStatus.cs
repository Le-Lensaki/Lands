using Assets.Scripts.Item.IDItem;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryStatus : LensakiMonoBehaviour
{

    [SerializeField] private InventorySO inventoryData;

    protected override void Awake()
    {
        base.Awake();
        //controller = GetComponent<InventoryController>();
        //inventory = new Dictionary<int, Item>();
        inventoryData.Initialize(null);
    }




    public void AddItem(Item value)
    {
        inventoryData.AddItem(value, 1);
    }

    public bool RemoveItem(Item item, int quatity)
    {
        return inventoryData.RemoveItem(item, quatity);
    }

    //public void CreateProduct(Item product)
    //{
    //    foreach (var material in product.MaterialProduct)
    //    {
    //        inventoryData.AddItem(material.item, -material.quatity);
    //    }

    //}

    //public void ChangeIsUsingItem(IDItem idItem)
    //{
    //    inventoryData.ChangeIsUsing(idItem);
    //}
    public void LoadInventory(List<InventoryItem> inventories)
    {
        inventoryData.Initialize(inventories);
    }

    public List<InventoryItem> GetCurentInventory()
    {
        List<InventoryItem> list = new List<InventoryItem>();

        foreach (var item in inventoryData.GetCurrentInventoryState())
        {
            list.Add(item.Value);
        }
        return list;
    }

    public List<InventoryItem> GetItemWithTag(TagName tag)
    {
        List<InventoryItem> list = new List<InventoryItem>();

        foreach (var item in inventoryData.GetCurrentInventoryState())
        {
            
            if (item.Value.item.TagName == tag)
            {
                list.Add(item.Value);
            }
        }
        return list;
    }

    public InventoryItem GetItemWithName(string name)
    {
        List<InventoryItem> list = new List<InventoryItem>();

        foreach (var item in inventoryData.GetCurrentInventoryState())
        {
            if (item.Value.item.GetName == name)
            {
                return item.Value;
            }
        }

        return InventoryItem.GetEmptyItem();
    }

    public InventoryItem GetItemInInventoryWithIdItem(IDItem idItem)
    {

        List<InventoryItem> list = new List<InventoryItem>();

        foreach (var item in inventoryData.GetCurrentInventoryState())
        {
            if (item.Value.item.GetId == idItem)
            {
                return item.Value;
            }
        }

        return InventoryItem.GetEmptyItem();
    }

    public void ChangeIndexItem(IDItem idItemBefore, IDItem idItemAfter)
    {

        inventoryData.ChangeIndexItem(idItemBefore, idItemAfter);
    }

    //public List<Item> GetListItemHaveMaterials()
    //{

    //    return inventoryData.GetListItemHaveMaterials();
    //}

    


    //public void ChangeIsUsing(Item itemGet)
    //{
    //    InventoryItem ivtItem = inventoryData.GetInventoryItem(itemGet);
    //    if (ivtItem.item != null)
    //    {
    //        UnableIsUsing();
    //        ivtItem.ChangeIsUsing();
    //    }

    //}

    //private void UnableIsUsing()
    //{
    //    foreach (var item in inventoryData.GetCurrentInventoryState())
    //    {
    //        if (item.Value.IsUsing)
    //        {
    //            item.Value.ChangeIsUsing();
    //        }
    //    }
    //}

    //public List<InventoryItem> ItemIsHolding()
    //{
    //    List<InventoryItem> list = new List<InventoryItem>();
    //    foreach (var item in inventoryData.GetCurrentInventoryState())
    //    {
    //        if (item.Value.isHolding)
    //        {
    //            list.Add(item.Value);
    //        }
    //    }
    //    return list;
    //}





    ////public List<InventoryItem> GetInvenotryItemWithTag(string tag)
    ////{
    ////    List<InventoryItem> list = new List<InventoryItem>();

    ////    foreach (var item in inventoryData.GetCurrentInventoryState())
    ////    {
    ////        if (item.Value.item.TagName == tag)
    ////        {
    ////            list.Add(item.Value);
    ////        }
    ////    }
    ////    return list;
    ////}

    //public Item GetItemWithName(string name)
    //{
    //    List<Item> listValue = inventory.Values.ToList();

    //    foreach (Item item in listValue)
    //    {

    //        if (item.GetName == name)
    //        {
    //            return item;
    //        }
    //    }
    //    return null;
    //}

    //public void UseItem(string nameItemUse)
    //{
    //    foreach (var item in inventory)
    //    {
    //        if (item.Value.GetName == nameItemUse)
    //        {
    //            //item.Value.MinusQuatity(1);
    //            PlayerController.Instance.Status.PlusHurryStat(item.Value.FoodStat);
    //            //if (item.Value.Quatity <= 0)
    //            //{
    //            //    inventory.Remove(item.Value.GetId);
    //            //    return;
    //            //}

    //        }
    //    }
    //}

    //public int CheckQuatityOfItem(string nameItem)
    //{
    //    foreach (var item in inventory)
    //    {
    //        if (item.Value.GetName == nameItem)
    //        {
    //            //return item.Value.Quatity;

    //        }
    //    }
    //    return 0;
    //}
}
