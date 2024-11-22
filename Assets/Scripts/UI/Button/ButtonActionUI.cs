using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonActionUI : BaseButton, IPointerDownHandler, IPointerUpHandler
{
    private bool isHolding = false;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadComponent(ref button);
    }
    protected override void OnClick()
    {
        //InputManager.Instance.PlayerAction();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isHolding = true;
        InputManager.Instance.PlayerAction();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHolding = false;
        InputManager.Instance.PlayerStop();
    }

    private void Update()
    {
        if (isHolding)
        {

            InputManager.Instance.PlayerAction();
        }
    }
}
