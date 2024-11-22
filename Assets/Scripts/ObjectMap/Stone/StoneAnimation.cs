using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class StoneAnimation : LensakiMonoBehaviour
{
    [SerializeField] protected Animator anim;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadStoneAnimator();
    }

    protected virtual void LoadStoneAnimator()
    {
        if (anim != null) return;
        anim = this.GetComponent<Animator>();

        Debug.Log(transform.name + ": LoadStoneAnimator", gameObject);
    }

    public virtual void EventAnimationTreeIsChopped()
    {
        //anim.SetBool("Chopped", false);
    }

    //public virtual void IsChopped()
    //{
    //    anim.SetBool("Chopped", true);
    //}

   
}
