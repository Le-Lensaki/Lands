using Assets.Scripts.Item.IDItem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : ObjectController
{

    //[SerializeField] protected PlayerStatus status;

    [SerializeField] protected TreeAnimation anim;
    [SerializeField] protected Sprite rootTree;
    [SerializeField] protected Sprite Tree;

    protected override void Start()
    {
        base.Start();
        idItemAction = IDItem.Axe;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadComponent(ref anim);
    }

    public void IsChopped()
    {
        anim.IsChopped();
    }

    public void EventAnimationTreeIsDrop()
    {

        //SpawnerManager.Instance.GetSpawner<ObjectDropItemSpawner>().Drop(objectSO.dropList, transform.position);
        anim.EventAnimationTreeIsDropped();
        

    }

    public void IsDrop()
    {
        anim.IsDrop();
    }


    protected override void OnDead()
    {
        base.OnDead();
        this.GetComponent<Animator>().enabled = false;
        //transform.GetComponent<SpriteRenderer>().sprite = rootTree;
        //this.IsDrop(); 
    }

    public override void Action()
    {
        base.Action();
        IsChopped();
    }    

}
