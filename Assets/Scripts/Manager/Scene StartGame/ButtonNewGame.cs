using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonNewGame : BaseButton
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
        AsyncLoader.Instance.LoadMap("Map1");
    }
}
