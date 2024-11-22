using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonSave1 : BaseButton
{
    [SerializeField] protected TMP_Text dateSave1;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadComponent(ref button);
        this.LoadDateSave();
    }

    protected void LoadDateSave()
    {
        if (dateSave1 != null) return;

        dateSave1 = transform.Find("DateSave1").GetComponent<TMP_Text>();
        Debug.Log(transform.name + ": LoadDateSave", gameObject);
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        UpdateDateSave1();
    }


    protected override void OnClick()
    {
       
        SaveManager.Instance.SaveGame1();
        UpdateDateSave1();
    }

    protected void UpdateDateSave1()
    {
        dateSave1.text = SaveManager.Instance.SaveData1.timeSave;
    }    
}
