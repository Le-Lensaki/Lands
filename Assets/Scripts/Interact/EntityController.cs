using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityController : LensakiMonoBehaviour, IInteractable
{
    [SerializeField] protected IDFurnitureProduct iDFurnitureProduct;
    public IDFurnitureProduct IDFurnitureProduct => iDFurnitureProduct;

    [SerializeField] protected HighLightEntityController highLightEntity;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHighLightEntity();
    }

    protected virtual void LoadHighLightEntity()
    {
        if (highLightEntity != null) return;

        highLightEntity = transform.GetComponentInChildren<HighLightEntityController>();
        //highLightEntity.gameObject.SetActive(false);
        Debug.Log(transform.name + " : LoadHighLightEntity", gameObject);
    }

    public void HighLight()
    {
        highLightEntity.gameObject.SetActive(true);
        InteractDialogController.Instance.EnableDialog();
    }

    public void UnHighLight()
    {
        highLightEntity.gameObject.SetActive(false);
        InteractDialogController.Instance.DisableDialog();
    }
    public virtual void Interact()
    {

    }
}
