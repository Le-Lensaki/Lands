using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BoatAnimation : LensakiMonoBehaviour
{
    protected Animator anim;
    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
    }
    
    protected virtual void LoadAnimator()
    {
        if (anim != null) return;

        anim = gameObject.GetComponent<Animator>();
        Debug.Log(transform.name + " : LoadAnimator", gameObject);

    }
    #endregion


    public void PlayAnimationRunBoat()
    {
        anim.Play("BoatRun");
    }

    public void PlayAnimationStopBoatIdle()
    {
        anim.Play("BoatStopIdle");
    }

    public void PlayAnimationBoatIdle()
    {
        anim.Play("BoatIdle");
    }
}
