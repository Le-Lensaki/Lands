using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HightLightController : LensakiMonoBehaviour
{
    public void HightLight()
    {
        transform.gameObject.SetActive(true);
    }
    public void UnHightLight()
    {
        transform.gameObject.SetActive(false);
    }
}
