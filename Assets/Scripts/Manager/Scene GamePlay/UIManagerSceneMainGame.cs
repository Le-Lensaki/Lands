using Assets.Scripts.Item.IDItem;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManagerSceneMainGame : Singleton<UIManagerSceneMainGame>
{
    [Header ("ListUIScene")]
    [SerializeField] private List<GameObject> listUIScene;

    [Header("UI Game")]
    [SerializeField] private GameObject uIInventory;
    [SerializeField] private GameObject uIItemHold;
    [SerializeField] private GameObject uIDiscriptionItem;
    public GameObject UIDiscriptionItem => uIDiscriptionItem;

    [SerializeField] private GameObject uIManufactory;
    [SerializeField] private GameObject uIMenuProduct;
    [SerializeField] private GameObject uIStatus;
    [SerializeField] private GameObject uIDialogueBox;
    [SerializeField] private GameObject uIChoiceDialog;
    [SerializeField] private GameObject uITalkDialog;
    [SerializeField] private GameObject uIInteractDialog;
    [SerializeField] private GameObject uIAvatar;
    [SerializeField] private GameObject uIWeather;
    [SerializeField] private GameObject uIButtonSetting;
    [SerializeField] private GameObject uIButtonOpenBag;
    [SerializeField] private GameObject uIMission;
    [SerializeField] private GameObject uIFileSave;
    [SerializeField] private GameObject uISetting;
    [SerializeField] private GameObject uIJoyStick;
    [SerializeField] private GameObject uIButtonAction;
    [SerializeField] private GameObject uIDoYouWantExit;
    [SerializeField] private GameObject uIYouLose;
    [SerializeField] private GameObject holderTextLoot;


    [SerializeField] protected List<GameObject> slotsHoldItemUI;

    public List<GameObject> SlotsHoldItemUI { get { return slotsHoldItemUI; } }

    [SerializeField] protected List<GameObject> slotsHoldItemInventory;

    public List<GameObject> SlotsHoldItemInventory { get { return slotsHoldItemInventory; } }

    [SerializeField] private List<GameObject> slotItem;
    public List<GameObject> SlotItem { get { return slotItem; } }

    [SerializeField] private List<GameObject> listUIMenuProduct;

    [SerializeField] private List<GameObject> listUIMaterialProduct;

    [SerializeField] private List<GameObject> listUITag;


    [Header("Tag Inventory")]
    [SerializeField] private TagName tagInventory;
    public TagName TagInventory { get { return tagInventory; } }


    #region LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();


        LoadGameObjectByName(ref uIInventory, "UIInventory");
        AddListGameObjectOfManager(ref listUIScene, ref uIInventory);

        LoadGameObjectByName(ref uIItemHold, "UIItemHold");
        AddListGameObjectOfManager(ref listUIScene, ref uIItemHold);

        LoadGameObjectByName(ref uIDiscriptionItem, "UIDiscriptionItem");
        AddListGameObjectOfManager(ref listUIScene, ref uIDiscriptionItem);

        LoadGameObjectByName(ref uIManufactory, "UIManufactory");
        AddListGameObjectOfManager(ref listUIScene, ref uIManufactory);

        LoadGameObjectByName(ref uIMenuProduct, "UIMenuProduct");
        AddListGameObjectOfManager(ref listUIScene, ref uIMenuProduct);

        LoadGameObjectByName(ref uIStatus, "UIStatus");
        AddListGameObjectOfManager(ref listUIScene, ref uIStatus);

        LoadGameObjectByName(ref uIDialogueBox, "UIDialogueBox");
        AddListGameObjectOfManager(ref listUIScene, ref uIDialogueBox);

        LoadGameObjectByName(ref uIChoiceDialog, "UIChoiceDialog");
        AddListGameObjectOfManager(ref listUIScene, ref uIChoiceDialog);

        LoadGameObjectByName(ref uITalkDialog, "UITalkDialog");
        AddListGameObjectOfManager(ref listUIScene, ref uITalkDialog);

        LoadGameObjectByName(ref uIInteractDialog, "UIInteractDialog");
        AddListGameObjectOfManager(ref listUIScene, ref uIInteractDialog);

        LoadGameObjectByName(ref uIAvatar, "UIAvatar");
        AddListGameObjectOfManager(ref listUIScene, ref uIAvatar);

        LoadGameObjectByName(ref uIWeather, "UIWeather");
        AddListGameObjectOfManager(ref listUIScene, ref uIWeather);

        LoadGameObjectByName(ref uIButtonSetting, "UIButtonSetting");
        AddListGameObjectOfManager(ref listUIScene, ref uIButtonSetting);

        LoadGameObjectByName(ref uIButtonOpenBag, "UIButtonOpenBag");
        AddListGameObjectOfManager(ref listUIScene, ref uIButtonOpenBag);

        LoadGameObjectByName(ref uIMission, "UIMission");
        AddListGameObjectOfManager(ref listUIScene, ref uIMission);

        LoadGameObjectByName(ref uISetting, "UISetting");
        AddListGameObjectOfManager(ref listUIScene, ref uISetting);

        LoadGameObjectByName(ref uIFileSave, "UIFileSave");
        AddListGameObjectOfManager(ref listUIScene, ref uIFileSave);

        LoadGameObjectByName(ref uIJoyStick, "UIJoyStick");
        AddListGameObjectOfManager(ref listUIScene, ref uIJoyStick);

        LoadGameObjectByName(ref uIButtonAction, "UIButtonAction");
        AddListGameObjectOfManager(ref listUIScene, ref uIButtonAction);

        LoadGameObjectByName(ref holderTextLoot, "HolderTextLoot");
        AddListGameObjectOfManager(ref listUIScene, ref holderTextLoot);

        LoadGameObjectByName(ref uIDoYouWantExit, "UIDoYouWantExit");
        AddListGameObjectOfManager(ref listUIScene, ref uIDoYouWantExit);

        LoadGameObjectByName(ref uIYouLose, "UIYouLose");
        AddListGameObjectOfManager(ref listUIScene, ref uIYouLose);

        this.LoadListUIMenuProduct();
        this.LoadListUIMaterialProduct();
        this.LoadSlotsHoldItemUI();
        this.LoadSlotsHoldItemInventory();
        this.LoadSlotsItem();
        this.LoadListUITag();
        this.LoadTagInventory();
    }
    
    private void LoadListUIMaterialProduct()
    {
        if (listUIMaterialProduct.Count > 0) return;

        for (int i = 1; i < 13; i++)
        {
            GameObject element = GameObject.Find("MaterialSlot_" + i);

            AddListGameObjectOfManager(ref listUIMaterialProduct, ref element);
        }
        Debug.Log(transform.name + ": LoadListUIMaterialProduct", gameObject);
    }
    protected virtual void LoadSlotsHoldItemUI()
    {
        if (slotsHoldItemUI.Count > 0) return;

        for (int i = 1; i < 8; i++)
        {
            GameObject element = GameObject.Find("SlotHoldItemUI_" + i);

            AddListGameObjectOfManager(ref slotsHoldItemUI, ref element);
        }

        Debug.Log(transform.name + ": LoadSlotsHoldItemUI", gameObject);
    }

    protected virtual void LoadSlotsHoldItemInventory()
    {
        if (slotsHoldItemInventory.Count > 0) return;

        for (int i = 1; i < 8; i++)
        {
            GameObject element = GameObject.Find("SlotHoldInventory_" + i);

            AddListGameObjectOfManager(ref slotsHoldItemInventory, ref element);

        }

        Debug.Log(transform.name + ": LoadSlotsHoldItemInventory", gameObject);
    }

    protected virtual void LoadSlotsItem()
    {
        if (slotItem.Count > 0) return;

        for (int i = 1; i < 21; i++)
        {
            GameObject element = GameObject.Find("SlotItem_" + i);

            AddListGameObjectOfManager(ref slotItem, ref element);

            slotItem[i-1].transform.GetChild(2).gameObject.SetActive(false);
        }

        Debug.Log(transform.name + ": LoadSlotsItem", gameObject);

    }

    protected virtual void LoadTagInventory()
    {
        if (tagInventory != TagName.NoTag) return;

        tagInventory = TagName.Tool;

        Debug.Log(transform.name + ": LoadTagInventory", gameObject);
    }

    


    

    protected void LoadListUIMenuProduct()
    {
        if (listUIMenuProduct.Count > 0) return;

        listUIMenuProduct = new List<GameObject> { };
        for (int i = 1; i < 11; i++)
        {
            listUIMenuProduct.Add(GameObject.Find("Product_" + i));
        }

        Debug.Log(transform.name + ": LoadListUIMenuProduct", gameObject);
    }

    protected void LoadListUITag()
    { 
        if (listUITag.Count > 0) return;

        listUITag = new List<GameObject> { };
        for (int i = 1; i < 7; i++)
        {
            listUITag.Add(GameObject.Find("Tag_" + i));
        }

        Debug.Log(transform.name + ": LoadListUITag", gameObject);
    }


    #endregion


    protected override void Start()
    {
        ClearAllUI();
        ChangeScreenPlaying();

        AudioManager.Instance.PlayMusic(AudioClipName.background);

    }

    public void OpenCloseInventory()
    {
        SetSlotsItem();
        SetslotsHoldItem();
        if (uIInventory.activeSelf) ChangeScreenPlaying();
        else ChangeScreenInventory();
    }

    public void UIOpenChest()
    {
        GetMenuFurnitureProduct();
        ChangeScreenOpenChest();
    }
    public void UICloseChest()
    {
        ClearMaterialProduct();
        ChangeScreenPlaying();
    }

    public void OpenDiscription()
    {
        uIDiscriptionItem.SetActive(!uIDiscriptionItem.activeSelf);
    }


    public void ToggleMenuCreateProduct(bool isOpen)
    {
        uIManufactory.SetActive(isOpen);
        uIMenuProduct.SetActive(isOpen);
        OpenCloseInventory();
    }

    protected void SetslotsHoldItem()
    {
        for (int i = 0; i < 7; i++)
        {
            slotsHoldItemUI[i].GetComponent<ItemSlot>().SetIDItemSlot(slotsHoldItemInventory[i].GetComponent<ItemSlot>().IDItemSlot);
            slotsHoldItemUI[i].transform.GetChild(0).GetComponent<Image>().sprite = slotsHoldItemInventory[i].transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite;
            slotsHoldItemUI[i].transform.GetChild(0).GetComponent<Image>().color = slotsHoldItemInventory[i].transform.GetChild(0).GetChild(0).GetComponent<Image>().color;
        }
    }
    public void ClearItemSlotHold(IDItem iDItem)
    {
        for (int i = 0; i < 7; i++)
        {
            if(slotsHoldItemInventory[i].GetComponent<ItemSlot>().IDItemSlot == iDItem)
            {
                slotsHoldItemInventory[i].GetComponent<ItemSlot>().SetIDItemSlot(IDItem.NoItem);
                slotsHoldItemInventory[i].transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = null;
                slotsHoldItemInventory[i].transform.GetChild(0).GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);

                slotsHoldItemUI[i].GetComponent<ItemSlot>().SetIDItemSlot(IDItem.NoItem);
                slotsHoldItemUI[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                slotsHoldItemUI[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);
                slotsHoldItemUI[i].GetComponent<HighLightChosenHold>().HighLightUsing(false);
                break;
            }
        }
    }

    public void SetSlotsItem()
    {
        List<InventoryItem> list = InventoryController.Instance.GetItemWithTag(tagInventory);

        for (int i = 0; i < list.Count; i++)
        {
            slotItem[i].transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = list[i].item.Icon;
            slotItem[i].transform.GetChild(0).GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
            slotItem[i].transform.GetChild(1).GetComponent<Text>().text = list[i].quatity.ToString();
            slotItem[i].transform.GetComponent<ItemSlot>().SetIDItemSlot(list[i].item.GetId);
        }
        for (int i = list.Count; i < slotItem.Count; i++)
        {
            slotItem[i].transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = null;
            slotItem[i].transform.GetChild(0).GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);
            slotItem[i].transform.GetChild(1).GetComponent<Text>().text = "0";
            slotItem[i].transform.GetComponent<ItemSlot>().SetIDItemSlot(IDItem.NoItem);
        }
    }
    #region Tag
    public void ChangeTag(string tagName)
    {
        ClearUITag();
        switch (tagName)
        {
            case "Tag_1":
                ChangeTagToolInventory();
                break;
            case "Tag_2":
                ChangeTagMaterialInventory();
                break;
            case "Tag_3":
                ChangeTagFruitlInventory();
                break;
            case "Tag_4":
                ChangeTagSeedlInventory();
                break;
            case "Tag_5":
                ChangeTagToolInventory();
                break;
            case "Tag_6":
                ChangeTagProductInventory();
                break;
            default:
                ChangeTagToolInventory();
                break;


        }
    }

    protected void ClearUITag()
    {
        foreach (var item in listUITag)
        {
            item.GetComponent<ButtonTag>().UnSelected();
        }
        UIInventoryDescription.Instance.DisableDescriptionItem();
    }



    protected void ChangeTagToolInventory()
    {
        tagInventory = TagName.Tool;
        SetSlotsItem();
    }
    protected void ChangeTagMaterialInventory()
    {
        tagInventory = TagName.Material;
        SetSlotsItem();
    }
    protected void ChangeTagSeedlInventory()
    {
        tagInventory = TagName.Seed;
        SetSlotsItem();
    }
    protected void ChangeTagFruitlInventory()
    {
        tagInventory = TagName.Fruit;
        SetSlotsItem();
    }

    protected void ChangeTagProductInventory()
    {
        tagInventory = TagName.Product;
        SetSlotsItem();
    }

    #endregion

    private void GetMenuFurnitureProduct()
    {
        List<FurnitureProduct> listProduct = ManagerFurnitureProduct.Instance.GetListFurnitureProduct;
        HideUIMenuProduct();
        if (listProduct.Count > 0)
        {
            for (int i = 0; i < listProduct.Count; i++)
            {
                listUIMenuProduct[i].gameObject.SetActive(true);
                listUIMenuProduct[i].transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().sprite = listProduct[i].Icon;
                listUIMenuProduct[i].transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                listUIMenuProduct[i].transform.GetChild(1).GetComponent<TMP_Text>().text = listProduct[i].GetNameFurnitureProduct;
            }
        }
        

    }

    protected void HideUIMenuProduct()
    {
        for (int i = 0; i < listUIMenuProduct.Count; i++)
        {
            listUIMenuProduct[i].gameObject.SetActive(false);
        }
    }
    public void SetMaterialProduct(List<MaterialProduct> material)
    {
        for (int i = 0; i < material.Count; i++)
        {
            listUIMaterialProduct[i].transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = material[i].item.Icon;
            listUIMaterialProduct[i].transform.GetChild(0).GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);

            int materialHave = 0;
            InventoryItem item = InventoryController.Instance.GetItemWithName(material[i].item.GetName);


            if (!item.IsEmpty)
            {

                materialHave = item.quatity;

            }

            listUIMaterialProduct[i].transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>().text = materialHave + "/" + material[i].quatity;
        }

    }

    public void ClearMaterialProduct()
    {
        for (int i = 0; i < listUIMaterialProduct.Count; i++)
        {
            listUIMaterialProduct[i].transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = null;
            listUIMaterialProduct[i].transform.GetChild(0).GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);
            listUIMaterialProduct[i].transform.GetChild(0).GetChild(1).GetComponent<TMP_Text>().text = "0/0";
        }

    }

    public void ClearAllUI()
    {
        foreach (var item in listUIScene)
        {
            item.SetActive(false);
        }
    }
    public void OpenScreenSetting()
    {
       
        ClearAllUI();
        uISetting.SetActive(true);
        StartCoroutine(PauseTime());
    }
    IEnumerator PauseTime()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        GameManager.Instance.PauseGame();
    }
    public void OpenScreenSaveGame()
    {
       
        ClearAllUI();
        uIFileSave.SetActive(true);
        StartCoroutine(PauseTime());
        
    }

    public virtual void CloseUIFileSave()
    {
        ChangeScreenPlaying();
    }

    public virtual void OpenUIDoYouWantExit()
    {
        uIDoYouWantExit.SetActive(true);
    }

    public virtual void OpenUIYouLose()
    {

        uIYouLose.SetActive(true);
        StartCoroutine(PauseTime());
    }
    public virtual void CloseUIDoYouWantExit()
    {
        uIDoYouWantExit.SetActive(false);
    }

    #region Change Screen
    public void ChangeScreenInventory()
    {
        
        ClearAllUI();
        uIInventory.SetActive(true);
        StartCoroutine(PauseTime());
    }
    public void ChangeScreenPlaying()
    {
        ClearAllUI();
        uIStatus.SetActive(true);
        uIWeather.SetActive(true);

        uIMission.SetActive(true);
        uIButtonOpenBag.SetActive(true);
        uIButtonSetting.SetActive(true);

        uIItemHold.SetActive(true);   
        holderTextLoot.SetActive(true);

        uIButtonAction.SetActive(true);
        uIJoyStick.SetActive(true);
        GameManager.Instance.PlayGame();
    }
    
    
    
    public void ChangeScreenOpenDiaLogue()
    {
    
        ClearAllUI();
        uIStatus.SetActive(true);
        uIWeather.SetActive(true);

        uIMission.SetActive(true);
        uIButtonOpenBag.SetActive(true);
        uIButtonSetting.SetActive(true);
        StartCoroutine(PauseTime());
    }

    public void ChangeScreenOpenChest()
    {
        ClearAllUI();
        uIManufactory.SetActive(true);
        uIMenuProduct.SetActive(true);
        StartCoroutine(PauseTime());
    }
    #endregion
}