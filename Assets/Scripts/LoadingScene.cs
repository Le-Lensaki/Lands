using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScene : LensakiMonoBehaviour
{
    protected override void Start()
    {
        base.Start();
        AsyncLoader.Instance.LoadMap("StartGame");
    }
}
