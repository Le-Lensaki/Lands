using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSpeed : BaseButton
{

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadComponent(ref button);
    }
    protected override void OnClick()
    {
        InputManager.Instance.Speed();
        if (InputManager.Instance.SpeedUp)
        {
            transform.GetChild(0).GetComponent<TMP_Text>().color = Color.yellow;
        }
        else
        {
            transform.GetChild(0).GetComponent<TMP_Text>().color = Color.black;
        }
            
    }

}
