using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTalkQuest : BaseButton
{
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadComponent(ref button);
    }

    protected override void OnClick()
    {
        PlayerController.Instance.TalkQuest();
    }
}
