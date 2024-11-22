using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonLoadSave1 : BaseButton
{
    [SerializeField] protected TMP_Text dateSave1;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadComponent(ref button);
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        SetDateSave1();
    }

    protected void SetDateSave1()
    {
        if (SaveManager.Instance.SaveData1.timeSave != null)
        {
            string dateSave = SaveManager.Instance.SaveData1.timeSave;

            dateSave1.text = dateSave;
        }
    }    

    protected override void OnClick()
    {
        if (SaveManager.Instance.SaveData1.timeSave == null) return;
        SaveManager.Instance.LoadSave1();
        AsyncLoader.Instance.LoadMap("Map1");
    }
}
