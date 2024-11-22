using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragMoveUI : LensakiMonoBehaviour, IDragHandler
{
    protected Camera cam;
    protected override void Awake()
    {

        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    public void OnDrag(PointerEventData eventData)
    {

        transform.position = new Vector3(cam.ScreenToWorldPoint(Input.mousePosition).x, cam.ScreenToWorldPoint(Input.mousePosition).y, 0);

    }
}
