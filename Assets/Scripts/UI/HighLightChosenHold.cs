using Assets.Scripts.Item.IDItem;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HighLightChosenHold : LensakiMonoBehaviour, IPointerClickHandler
{
    [SerializeField] protected IDKeyNumber iDKeyNumber;
    [SerializeField] protected Transform highLightUsing;
    protected bool isHightLight;
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

    public void OnPointerClick(PointerEventData eventData)
    {
        if (transform.GetComponent<ItemSlot>().IDItemSlot == IDItem.NoItem) return;

        //if(isHightLight)
        //{
        //    UnhighlightSlotHold();
            
        //}
        //else
        //{
        //    HighlightSlotHold();  
        //}
        PlayerController.Instance.PlayerSetItemUse(iDKeyNumber);
        EventSystem.current.SetSelectedGameObject(gameObject);
    }

    public void HighlightSlotHold()
    {
        highLightUsing.gameObject.SetActive(true);
        highLightUsing.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 1f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
        isHightLight = true;
    }

    public void UnhighlightSlotHold()
    {
        highLightUsing.GetComponent<RectTransform>().DOScale(new Vector3(1f, 1f, 1f), 0.1f).OnComplete(() =>
        {
            highLightUsing.GetComponent<RectTransform>().DOKill();
            highLightUsing.gameObject.SetActive(false);
            isHightLight = false;
        });
    }
}
