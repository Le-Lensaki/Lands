using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerFurnitureProduct : Singleton<ManagerFurnitureProduct>
{
    [SerializeField] protected List<FurnitureProduct> listFurnitureProduct;
    public List<FurnitureProduct> GetListFurnitureProduct { get { return listFurnitureProduct; } }

    [SerializeField] protected List<EntityController> listEntity;
    public List<EntityController> ListEntity { get { return listEntity; } }

    [SerializeField] protected FurnitureProduct furnitureProductChosen;
    public FurnitureProduct FurnitureProductChosen => furnitureProductChosen;
    
   protected override void Awake()
    {
        base.Awake();
    }
    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadListFurnitureProduct();
        this.LoadListEntity();
    }


    protected virtual void LoadListFurnitureProduct()
    {
        if (listFurnitureProduct.Count > 0) return;
        string resPath = "FurnitureProduct/";
        FurnitureProduct[] furnitureProducts = Resources.LoadAll<FurnitureProduct>(resPath);
        foreach (var item in furnitureProducts)
        {
            this.listFurnitureProduct.Add(item);
        }
        Debug.LogWarning(transform.name + ": LoadListProduct " + resPath, gameObject);

    }

    private void LoadListEntity()
    {
        if (listEntity.Count > 0) return;
        listEntity = new List<EntityController>(FindObjectsByType<EntityController>(FindObjectsSortMode.None));
        foreach (var entity in listEntity)
        {
            if (entity.gameObject.name != "Chest")
            {
                entity.gameObject.SetActive(false);
            }
        }
        Debug.LogWarning(transform.name + ": LoadListEntity " ,gameObject);
    }
    #endregion



    public ListFurnitureSave CreateListFurnitureSave()
    {
        ListFurnitureSave furnitureSaveData = new ListFurnitureSave();

        foreach (var entity in listEntity)
        {
            FurnitureSaveData furnitureSave = new FurnitureSaveData
            {
                nameFurniture = entity.name,
                statusEnable = entity.gameObject.activeSelf,
            };
            furnitureSaveData.furnitureSaveData.Add(furnitureSave);
        }

        return furnitureSaveData;
    }
    public void SetListFurnitureSave(ListFurnitureSave listFurnitureSave)
    {
        for (int i = 0; i < listEntity.Count; i++)
        {
            if(listEntity[i].name == listFurnitureSave.furnitureSaveData[i].nameFurniture)
            {
                listEntity[i].gameObject.SetActive(listFurnitureSave.furnitureSaveData[i].statusEnable);
            }
        }
    }

    public void UnclockFurnitureProduct()
    {
        foreach (var entity in listEntity)
        {
            if (entity.IDFurnitureProduct == furnitureProductChosen.GetIDFurnitureProduct)
            {
                
                entity.gameObject.SetActive(true);
                SetIconProduct(furnitureProductChosen);
                listFurnitureProduct.Remove(furnitureProductChosen);
                break;
            }    
                
        }
    }    


    public FurnitureProduct GetProductWithName(string nameFurnitureProduct)
    {
        foreach (var furnitureProduct in GetListFurnitureProduct)
        {
            if(furnitureProduct.GetNameFurnitureProduct == nameFurnitureProduct) return furnitureProduct;
            
        }
        return null;
    }


    public void ChosenFurnitureProduct(string nameFurnitureProduct)
    {
        furnitureProductChosen = ManagerFurnitureProduct.Instance.GetProductWithName(nameFurnitureProduct);

        if (furnitureProductChosen != null)
        {
            SetIconProduct(furnitureProductChosen);
        }
        else
        {

            ClearIconProduct();
        }
    }

    private void SetIconProduct(FurnitureProduct furnitureProduct)
    {
        GameObject iconProduct = GameObject.Find("IconProduct");
        iconProduct.GetComponent<Image>().sprite = furnitureProduct.Icon;
        iconProduct.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        UIManagerSceneMainGame.Instance.SetMaterialProduct(furnitureProduct.MaterialFurnitureProducts);
    }
    private void ClearIconProduct()
    {
        furnitureProductChosen = null;
        GameObject iconProduct = GameObject.Find("IconProduct");
        iconProduct.GetComponent<Image>().sprite = null;
        iconProduct.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        UIManagerSceneMainGame.Instance.ClearMaterialProduct();
    }
}
