using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryAnimation : LensakiMonoBehaviour
{

    [SerializeField] private Image itemImage;
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text description;
    [SerializeField] private GameObject useButton;

    protected override void Awake()
    {
        base.Awake();
        //itemImage = GameObject.Find("IconDiscriptionItem").GetComponent<Image>();
        //title = GameObject.Find("TitleDiscription").GetComponent<TMP_Text>();
        //description = GameObject.Find("Discription").GetComponent<TMP_Text>();
        //useButton = GameObject.Find("UseButton");
        ResetDiscription();
    }

    public void ResetDiscription()
    {
        //this.itemImage.gameObject.SetActive(false);
        //this.title.text = "";
        //this.description.text = "";
        //this.useButton.gameObject.SetActive(false);
    }

    public void SetDiscription(InventoryItem item)
    {
        this.itemImage.gameObject.SetActive(true);
        this.itemImage.sprite = item.item.Icon;
        this.itemImage.color = new Color(1, 1, 1, 1);

        this.title.text = item.item.GetName;
        this.description.text = item.item.GetDiscription;
        //if(item.item.TagName == "Fruit") this.useButton.gameObject.SetActive(true);
    }




}
