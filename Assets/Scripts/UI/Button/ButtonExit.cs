using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonExit : BaseButton
{
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadComponent(ref button);
    }


    protected override void OnClick()
    {
        UIManagerSceneMainGame.Instance.OpenUIDoYouWantExit();
    }
}
