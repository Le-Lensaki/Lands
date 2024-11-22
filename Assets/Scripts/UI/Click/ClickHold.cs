using Assets.Scripts.Item.IDItem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickHold : Click
{
    [SerializeField] protected IDKeyNumber iDKeyNumber;
    public override void OnPointerClick(PointerEventData eventData)
    {
        PlayerController.Instance.PlayerSetItemUse(iDKeyNumber);
    }

}
