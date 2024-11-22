using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickProduct : Click, IDragHandler, IEndDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePos = InputManager.Instance.MouseWorldPos;
        mousePos.z = 0;
        transform.position = mousePos;
        transform.localScale = new Vector2(0.7f,0.7f);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localScale = new Vector2(1f, 1f);
    }


    public override void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log(transform.name);
    }
}
