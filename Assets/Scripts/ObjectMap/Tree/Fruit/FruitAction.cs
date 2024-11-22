using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class FruitAction : LensakiMonoBehaviour
{
    [SerializeField] protected Animator anim;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFruitAnimator();
    }

    protected virtual void LoadFruitAnimator()
    {
        if (anim != null) return;
        anim = this.GetComponent<Animator>();

        Debug.Log(transform.name + ": LoadFruitAnimator", gameObject);
    }

    public virtual void EventAnimationFruitIsDrop()
    {
        anim.SetBool("Drop", false);
    }

    public virtual void IsChopped()
    {
        anim.SetBool("Drop", true);
    }
}
