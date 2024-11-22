using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonYesExit : BaseButton
{
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadComponent(ref button);
    }

    protected override void OnClick()
    {

        GameManager.Instance.LoadMapNormal("StartGame");
    }
}