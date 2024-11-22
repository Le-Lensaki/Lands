using Assets.Scripts.Item.IDItem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : LensakiMonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] protected Transform realParent;
    [SerializeField] protected Transform slotItemReal;
    public Transform SlotItemReal { get { return slotItemReal; } }
    [SerializeField] protected Transform itemChangeSlot;
    [SerializeField] protected Image image;

    [SerializeField] protected IDItem iDItem;

    public IDItem IDItem { get { return iDItem; } }
    public virtual void SetRealParent(Transform realParent)
    {
        this.realParent = realParent;
    }
    public virtual void SetSlotItemReal(Transform slotItemReal)
    {
        this.slotItemReal = slotItemReal;
    }
    public virtual void SetItemChangeSlot(Transform itemChangeSlot)
    {
        this.itemChangeSlot = itemChangeSlot;
    }
    public virtual void ChangeItem(IDItem id)
    {
        this.itemChangeSlot.SetParent(this.realParent);
        this.iDItem = id;
    }    

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTransform();
        this.LoadItemReal();
        this.LoadImage();
    }

    protected virtual void LoadTransform()
    {
        if (realParent != null) return;
        this.realParent = transform.parent;

        Debug.Log(transform.name + ": LoadTransform", gameObject);
    }
    protected virtual void LoadItemReal()
    {
        if (slotItemReal != null) return;
        this.slotItemReal = transform.parent.parent;
        
        Debug.Log(transform.name + ": LoadItemReal", gameObject);
    }

    protected virtual void LoadImage()
    {
        if (image != null) return;
        this.image = GetComponent<Image>();

        Debug.Log(transform.name + ": LoadImage", gameObject);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        this.ReturnTransform();

        this.iDItem = this.slotItemReal.GetComponent<ItemSlot>().IDItemSlot;
        if (iDItem == IDItem.NoItem) return;
        transform.SetParent(transform.root);

        image.raycastTarget = false;

        AudioManager.Instance.PlaySFX(AudioClipName.drag);
    }

    protected void ReturnTransform()
    {
        this.realParent = transform.parent;
        this.slotItemReal = transform.parent.parent;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePos = InputManager.Instance.MouseWorldPos;
        mousePos.z = 0;
        transform.position = mousePos;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(this.realParent);
        image.raycastTarget = true;
        if (slotItemReal.GetComponent<SlotHold>() != null)
        {
            TakeOutHolding();
            return;
        }

        slotItemReal.GetComponent<ItemSlot>().SetIDItemSlot(iDItem);

        AudioManager.Instance.PlaySFX(AudioClipName.drop);
    }
    protected void TakeOutHolding()
    {
        transform.GetComponent<Image>().sprite = null;
        transform.GetComponent<Image>().color = new Color(255,255,255,0);

        slotItemReal.GetComponent<ItemSlot>().SetIDItemSlot(IDItem.NoItem);

        
    }

    

    
}
