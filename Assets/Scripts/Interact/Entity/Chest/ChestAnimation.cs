using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Animator))]
public class ChestAnimation : LensakiMonoBehaviour
{

    [SerializeField] protected Animator anim;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
    }

    protected virtual void LoadAnimator()
    {
        if (anim != null) return;
        anim = GetComponent<Animator>();
        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }


    public void ToggleInventory()
    {
        //UIManager.Instance.ToggleInventory();
    }
    public void Open()
    {
        //anim.SetBool("Open", true);
        //anim.SetBool("Idle", false);
        anim.Play("Open");
    }
    public void Close()
    {
        anim.Play("Close");
    }
    public void Idle()
    {
        //anim.SetBool("Idle", true);
    }

    public void OpenUIChest()
    {
        //UIManager.Instance.OpenChest();
    }
}
