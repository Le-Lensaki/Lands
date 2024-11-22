using Assets.Scripts.Item.IDItem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickEntity : Click
{

    public override void OnPointerClick(PointerEventData eventData)
    {
        //UIManager.Instance.OpenDiscription();
        //UIInventoryDiscription.Instance.SetDiscription(InventoryController.Instance.GetItemWithIdItem(transform.GetComponent<ItemSlot>().IDItemSlot));
       
        //transform.GetComponent<IInteractable>().Interact();
    }
}
