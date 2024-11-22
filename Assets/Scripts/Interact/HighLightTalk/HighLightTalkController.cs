using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HighLightTalkController : LensakiMonoBehaviour
{
    protected HighLightTalkAnimation anim;

    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadComponent(ref anim);

    }
    
    #endregion


}
