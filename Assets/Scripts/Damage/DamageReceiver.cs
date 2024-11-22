using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider2D))]
public abstract class DamageReceiver : LensakiMonoBehaviour
{

    [SerializeField] protected Collider2D colliderObject;
    [SerializeField] protected int currentHP = 5;
    [SerializeField] protected bool isDead = false;
    


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
    }

    protected virtual void LoadCollider()
    {
        if (this.colliderObject != null) return;
        this.colliderObject = GetComponent<Collider2D>();

        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }
    

    public virtual void Reborn(int hpMax)
    {
        this.currentHP = hpMax;
        this.isDead = false;
    }

    public virtual void Deduct(int deduct)
    {
        if (this.isDead) return;

        this.currentHP -= deduct;
        if (this.currentHP < 0) this.currentHP = 0;
        this.CheckIsDead();
    }

    protected virtual void CheckIsDead()
    {
        if (!this.IsDead()) return;
        this.isDead = true;
        this.OnDead();
    }

    protected virtual bool IsDead()
    {
        return this.currentHP <= 0;
    }

    protected abstract void OnDead();
}
