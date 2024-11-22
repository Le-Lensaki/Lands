using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class TreeAnimation : LensakiMonoBehaviour
{
    [SerializeField] protected Animator anim;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTreeAnimator();
    }

    protected virtual void LoadTreeAnimator()
    {
        if (anim != null) return;
        anim = this.GetComponent<Animator>();

        Debug.Log(transform.name + ": LoadTreeAnimator", gameObject);
    }

    public virtual void EventAnimationTreeIsChopped()
    {
        anim.SetBool("Chopped", false);
    }

    public virtual void IsChopped()
    {
        anim.Play("Chopped");
    }

    public virtual void EventAnimationTreeIsDropped()
    {
        anim.SetBool("Drop", false);

        //transform.gameObject.SetActive(false);

    }

    public virtual void IsDrop()
    {
        anim.SetBool("Drop", true);
        
    }
}
