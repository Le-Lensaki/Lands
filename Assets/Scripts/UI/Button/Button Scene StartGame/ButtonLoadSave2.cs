using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonLoadSave2 : BaseButton
{
    [SerializeField] protected TMP_Text dateSave2;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadComponent(ref button);
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        SetDateSave2();
    }

    protected void SetDateSave2()
    {
        if (SaveManager.Instance.SaveData2.timeSave != null)
        {
            string dateSave = SaveManager.Instance.SaveData2.timeSave;
            dateSave2.text = dateSave;
        }
    }    

    protected override void OnClick()
    {
        if (SaveManager.Instance.SaveData2.timeSave == null) return;
        SaveManager.Instance.LoadSave2();
        AsyncLoader.Instance.LoadMap("Map1");
    }
}
