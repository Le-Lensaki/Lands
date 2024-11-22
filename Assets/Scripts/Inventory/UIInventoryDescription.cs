using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInventoryDescription : Singleton<UIInventoryDescription>
{
    [SerializeField] protected Item item;
    [SerializeField] private Image iconDescriptionItem;
    [SerializeField] private TMP_Text titleDescriptionItem;
    [SerializeField] private TMP_Text descriptionItem;
    [SerializeField] private GameObject buttonUseItem;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadIconDescriptionItem();
        this.LoadTitleDescriptionItem();
        this.LoadDescriptionItem();
        this.LoadButtonUseItem();
        this.ResetDescription();
    }

    #region LoadComponent
    protected virtual void LoadIconDescriptionItem()
    {
        if (iconDescriptionItem != null) return;

        iconDescriptionItem = GameObject.Find("IconDiscriptionItem").GetComponent<Image>();

        Debug.Log(transform.name + ": LoadIconDiscriptionItem", gameObject);
    }

    protected virtual void LoadTitleDescriptionItem()
    {
        if (titleDescriptionItem != null) return;

        titleDescriptionItem = GameObject.Find("TitleDiscriptionItem").GetComponent<TMP_Text>();

        Debug.Log(transform.name + ": LoadTitleDiscriptionItem", gameObject);
    }

    protected virtual void LoadDescriptionItem()
    {
        if (descriptionItem != null) return;

        descriptionItem = GameObject.Find("DiscriptionItem").GetComponent<TMP_Text>();

        Debug.Log(transform.name + ": LoadDiscriptionItem", gameObject);
    }

    protected virtual void LoadButtonUseItem()
    {
        if (buttonUseItem != null) return;

        buttonUseItem = GameObject.Find("ButtonUseItem");

        Debug.Log(transform.name + ": LoadButtonUseItem", gameObject);
    }
    #endregion

    public void ResetDescription()
    {
        this.item = null;
        this.iconDescriptionItem.sprite = null;
        this.iconDescriptionItem.color = new Color(1, 1, 1, 0);
        this.titleDescriptionItem.text = "";
        this.descriptionItem.text = "";
        this.buttonUseItem.gameObject.SetActive(false);
    }

    public void SetDescription(Item item)
    {
        if (item == null) return;
        this.item = item;
        this.iconDescriptionItem.sprite = item.Icon;
        this.iconDescriptionItem.color = new Color(1, 1, 1, 1);
        this.titleDescriptionItem.text = item.GetName;
        this.descriptionItem.text = item.GetDiscription;
        if(item.FoodStat > 0) this.buttonUseItem.gameObject.SetActive(true);
    }


    public void EnableDescriptionItem(Item item)
    {
        SetDescription(item);
        transform.gameObject.SetActive(true);
    }

    public void DisableDescriptionItem()
    {
        ResetDescription();
        transform.gameObject.SetActive(false);
    }


    public virtual void UseFruit()
    {
        if(InventoryController.Instance.RemoveItem(item, 1))
        {
            PlayerController.Instance.PlusHP(item.FoodStat);
            UIManagerSceneMainGame.Instance.SetSlotsItem();
        }
        if(InventoryController.Instance.GetItemInInventoryWithIdItem(item.GetId).IsEmpty)
        {
            DisableDescriptionItem();
            UIManagerSceneMainGame.Instance.SetSlotsItem();
        }    
    }
}
