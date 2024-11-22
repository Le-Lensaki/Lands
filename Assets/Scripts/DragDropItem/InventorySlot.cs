using Assets.Scripts.Item.IDItem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : LensakiMonoBehaviour, IDropHandler
{

    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
    
        if (transform.GetComponent<SlotHold>() != null)
        {
            SetHolding(dropped);
            return;
        }
        if(dropped.GetComponent<DraggableItem>().SlotItemReal.GetComponent<SlotHold>() != null)
        {
            return;
        }    
        ChangeSlot(dropped);
    }

    protected void SetHolding(GameObject dropped)
    {
        DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();

        transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = dropped.transform.GetComponent<Image>().sprite;
        transform.GetChild(0).GetChild(0).GetComponent<Image>().color = new Color(255, 255, 255, 255);
        transform.GetComponent<ItemSlot>().SetIDItemSlot(draggableItem.IDItem);
    }


    protected void ChangeSlot(GameObject dropped)
    {
        DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();

        InventoryController.Instance.ChangeIndexItem(draggableItem.IDItem, transform.GetComponent<ItemSlot>().IDItemSlot);
        if (transform.childCount > 0 && transform.GetChild(0).childCount > 0)
        {
            draggableItem.SetItemChangeSlot(transform.GetChild(0).GetChild(0));

            IDItem iDItem = draggableItem.IDItem;

            draggableItem.ChangeItem(transform.GetComponent<ItemSlot>().IDItemSlot);

            transform.GetComponent<ItemSlot>().SetIDItemSlot(iDItem);

            draggableItem.SetRealParent(transform.GetChild(0));
        }

    }

}
