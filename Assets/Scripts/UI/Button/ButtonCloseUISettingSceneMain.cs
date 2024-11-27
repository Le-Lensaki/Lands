using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCloseUISettingSceneMain : BaseButton
{
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadButton();
    }

    protected virtual void LoadButton()
    {
        if (button != null) return;
        button = GetComponent<Button>();

        Debug.Log(transform.name + ": LoadButton", gameObject);
    }

    protected override void OnClick()
    {
        UIManagerSceneMainGame.Instance.CloseUISetting();
    }
}