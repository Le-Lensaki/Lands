using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonChosenFurnitureProduct : BaseButton
{
    [SerializeField] protected TMP_Text titleProduct;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadComponent(ref button);
        LoadTitleProduct();
    }
    protected virtual void LoadTitleProduct()
    {
        if (titleProduct != null) return;
        titleProduct = transform.Find("TitleProduct").GetComponent<TMP_Text>();

        Debug.Log(transform.name + ": LoadTitleProduct ", gameObject);
    }


    protected override void OnClick()
    {
        ManagerFurnitureProduct.Instance.ChosenFurnitureProduct(titleProduct.text);
    }
}
