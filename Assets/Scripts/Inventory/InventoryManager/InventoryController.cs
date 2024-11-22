using Assets.Scripts.Item.IDItem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : Singleton<InventoryController>
{


    [SerializeField] protected InventoryStatus status;


    [SerializeField] protected InventoryAnimation anim;


    protected override void Awake()
    {
        base.Awake();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadComponent(ref anim);
        LoadComponent(ref status);
    }

    public void AddItem(Item item)
    {
        status.AddItem(item);
    }

    public bool RemoveItem(Item item, int quatity)
    {
        return status.RemoveItem(item, quatity);
    }

    public void LoadInventory(List<InventoryItem> inventories)
    {
        status.LoadInventory(inventories);
    }

    public List<InventoryItem> GetCurentInventory()
    {
        return status.GetCurentInventory();
    }

    public List<InventoryItem> GetItemWithTag(TagName tag)
    {
        return status.GetItemWithTag(tag);
    }

    public InventoryItem GetItemWithName(string name)
    {
        return status.GetItemWithName(name);
    }

    public InventoryItem GetItemInInventoryWithIdItem(IDItem idItem)
    {
        return status.GetItemInInventoryWithIdItem(idItem);
    }

    public void ChangeIndexItem(IDItem idItemBefore, IDItem idItemAfter)
    {
        status.ChangeIndexItem(idItemBefore, idItemAfter);
    }

    public bool CheckUnblockFurnitureProduct(List<MaterialProduct> material)
    {


        foreach (var materialProduct in material)
        {

            var inventoryItem = GetItemInInventoryWithIdItem(materialProduct.item.GetId);
            if (inventoryItem.IsEmpty || inventoryItem.quatity < materialProduct.quatity)
            {
                
                return false;
            }

        }
    
        foreach (var materialProduct in material)
        {
            RemoveItem(materialProduct.item, materialProduct.quatity);
        }

        return true;

    }

}
