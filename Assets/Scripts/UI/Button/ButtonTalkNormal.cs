using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTalkNormal : BaseButton
{
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadComponent(ref button);
    }

    protected override void OnClick()
    {
        PlayerController.Instance.TalkNormal();    
    }
}
