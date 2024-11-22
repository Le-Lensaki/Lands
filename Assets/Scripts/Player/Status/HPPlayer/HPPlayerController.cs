using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPPlayerController : Singleton<HPPlayerController>
{
    protected HPPlayerAnimation anim;

    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadComponent(ref anim);
    }
    #endregion
 

    public virtual void UpdateHP(int currentHP,int maxHP)
    {
        anim.UpdateHPBar(currentHP,maxHP);
        if (currentHP <= 0) UIManagerSceneMainGame.Instance.OpenUIYouLose();
    }



}
