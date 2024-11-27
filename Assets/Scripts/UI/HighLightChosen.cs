using Assets.Scripts.Item.IDItem;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HighLightChosen : LensakiMonoBehaviour, IPointerClickHandler, IDeselectHandler
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

    public void OnPointerClick(PointerEventData eventData)
    {
        if (transform.GetComponent<ItemSlot>().IDItemSlot == IDItem.NoItem) return;
        HighlightSlot();

        UIInventoryDescription.Instance.EnableDescriptionItem(InventoryController.Instance.GetItemInInventoryWithIdItem(transform.GetComponent<ItemSlot>().IDItemSlot).item);

        EventSystem.current.SetSelectedGameObject(gameObject);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        UnhighlightSlot();
    }
    private void HighlightSlot()
    {
        highLightUsing.gameObject.SetActive(true);
        highLightUsing.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 1f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
    }

    private void UnhighlightSlot()
    {
        highLightUsing.GetComponent<RectTransform>().DOScale(new Vector3(1f, 1f, 1f), 0.1f).OnComplete(() =>
        {
            highLightUsing.GetComponent<RectTransform>().DOKill();
            highLightUsing.gameObject.SetActive(false);
        });
    }

}
