using Assets.Scripts.Item.IDItem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HighLightChosenHold : LensakiMonoBehaviour, IPointerClickHandler,IDeselectHandler
{
    [SerializeField] protected Transform highLightUsing;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHighLightUsing();
    }


    protected virtual void LoadHighLightUsing()
    {
        if (highLightUsing != null) return;
        this.highLightUsing = transform.Find("HighLightUsing");
        highLightUsing.gameObject.SetActive(false);


        Debug.Log(transform.name + ": LoadHighLightUsing", gameObject);
    }

    public virtual void HighLightUsing(bool enable)
    {
        highLightUsing.gameObject.SetActive(enable);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (transform.GetComponent<ItemSlot>().IDItemSlot == IDItem.NoItem) return;

        PlayerController.Instance.PlayerSelectedSlot(transform.name);
        EventSystem.current.SetSelectedGameObject(gameObject);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        PlayerController.Instance.PlayerDeselectedSlot();
        //UIInventoryDiscription.Instance.DisableDiscriptionItem();
    }
}
