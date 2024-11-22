using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : EntityController
{
    [SerializeField] protected ChestStatus status;

    [SerializeField] protected ChestAnimation anim;
    [SerializeField] protected Dialogue dialogueCompleted;

    protected override void Awake()
    {
        base.Awake();
    }
    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadComponent(ref status);
        LoadComponent(ref anim);
        
    }
    #endregion
    public virtual void OpenChest()
    {
        anim.Open();
        AudioManager.Instance.PlaySFX(AudioClipName.openChest);
    }
    public virtual void CloseChest()
    {
        UIManagerSceneMainGame.Instance.UICloseChest();
        anim.Close();
        
        AudioManager.Instance.PlaySFX(AudioClipName.closeChest);
    }    

    public virtual void EventAnimationOpenChest()
    {
        UIManagerSceneMainGame.Instance.UIOpenChest();
    }

    
    public virtual void UnblockFurnitureProduct()
    {
        if (ManagerFurnitureProduct.Instance.FurnitureProductChosen == null) return;
        if(InventoryController.Instance.CheckUnblockFurnitureProduct(ManagerFurnitureProduct.Instance.FurnitureProductChosen.MaterialFurnitureProducts))
        {
            ManagerFurnitureProduct.Instance.UnclockFurnitureProduct();
            CloseChest();
            DialogueController.Instance.Initialize(dialogueCompleted, null);
        }    
    }

    public override void Interact()
    {
        base.Interact();
        OpenChest();
    }
}

