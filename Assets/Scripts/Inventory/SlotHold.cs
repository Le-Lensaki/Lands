using Assets.Scripts.Item.IDItem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotHold : LensakiMonoBehaviour
{
    [SerializeField] protected IDKeyNumber keyNumber;

    public IDKeyNumber KeyNumber { get { return keyNumber; } }
}
