using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonSave2 : BaseButton
{
    [SerializeField] protected TMP_Text dateSave2;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadComponent(ref button);
        this.LoadDateSave();
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        UpdateDateSave2();
    }

    protected void LoadDateSave()
    {
        if (dateSave2 != null) return;

        dateSave2 = transform.Find("DateSave2").GetComponent<TMP_Text>();
        Debug.Log(transform.name + ": LoadDateSave", gameObject);
    }
    protected override void OnClick()
    {
        SaveManager.Instance.SaveGame2();
        UpdateDateSave2();
    }
    protected void UpdateDateSave2()
    {
        dateSave2.text = SaveManager.Instance.SaveData2.timeSave;
    }
}
