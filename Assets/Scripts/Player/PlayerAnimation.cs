using Assets.Scripts.Item.IDItem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : LensakiMonoBehaviour
{
    [SerializeField] protected Animator anim;

    [SerializeField] protected Vector2 lastVector;

    public Vector2 LastVector => lastVector;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerAnimator();
    }
    #region LoadComponents
    protected virtual void LoadPlayerAnimator()
    {
        if (anim != null) return;
        anim = this.GetComponent<Animator>();
       

        Debug.Log(transform.name + ": LoadPlayerAnimator", gameObject);
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        lastVector = Vector2.zero;
    }
    #endregion

    public void ChangeAnimationPlayer(Vector2 velocity, float speed)
    {
        if (velocity != Vector2.zero)
        {
            anim.SetFloat("Speed", speed);
            lastVector = velocity;
        }
        else
        {
            anim.SetFloat("Speed", 0);
        }
        anim.SetFloat("x", lastVector.x);
        anim.SetFloat("y", lastVector.y);
    }

    public void Action(IDItem iDItem, bool action)
    {
        for (int i = 0; i < anim.parameterCount; i++)
        {
            if (anim.parameters[i].name != iDItem.ToString()) continue;

            anim.SetBool(iDItem.ToString(), action);
        }
    }

    public void SetLastVector(Vector2 vector2)
    {
        lastVector = vector2;
    }    
}
