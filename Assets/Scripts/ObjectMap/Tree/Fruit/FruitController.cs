using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : LensakiMonoBehaviour
{
    [SerializeField] protected FruitAction action;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFruitAction();
    }

    protected virtual void LoadFruitAction()
    {
        if (this.action != null) return;

        action = transform.GetComponent<FruitAction>();

        Debug.Log(transform.name + ": LoadFruitAction", gameObject);
    }
    public virtual void EventAnimationFruitIsDrop()
    {
        action.EventAnimationFruitIsDrop();
    }

    public virtual void IsChopped()
    {
        action.IsChopped();
    }

}
