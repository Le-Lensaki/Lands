using Assets.Scripts.Item.IDItem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : DamageReceiver, IActionable, IHighLight
{
    [SerializeField] protected HightLightController hightLightSelected;
    public HightLightController HightLightSelected { get => hightLightSelected; }

    [SerializeField] protected ObjectSO objectSO;
    public ObjectSO ObjectSO => objectSO;

    [SerializeField] protected SliderHP sliderHP;

    [SerializeField] protected IDItem idItemAction;
    public IDItem IDItemAction => idItemAction;
    protected override void OnEnable()
    {
        this.Reborn(objectSO.hpMax);
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.Reborn(objectSO.hpMax);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHightLightSelected();
        this.LoadObjectSO();
        this.LoadSliderHP();
    }
    protected virtual void LoadSliderHP()
    {
        if (this.sliderHP != null) return;
        if (transform.GetChild(0).Find("SliderHP") == null) return;
        this.sliderHP = transform.GetChild(0).Find("SliderHP").GetChild(0).GetComponent<SliderHP>();

        Debug.Log(transform.name + ": LoadSliderHP", gameObject);
    }
    protected virtual void LoadHightLightSelected()
    {
        if (this.hightLightSelected != null) return;
        this.hightLightSelected = transform.Find("HighLightSelected").GetComponent<HightLightController>();
        this.hightLightSelected.gameObject.SetActive(false);
        Debug.LogWarning(transform.name + ": LoadHightLightSelected", gameObject);
    }

    protected virtual void LoadObjectSO()
    {
        if (this.objectSO != null) return;
        string resPath = "Object/" + transform.name;
        this.objectSO = Resources.Load<ObjectSO>(resPath);
        Debug.LogWarning(transform.name + ": LoadJunkSO " + resPath, gameObject);
    }
    
    protected override void OnDead()
    {

        SpawnerManager.Instance.GetSpawner<ObjectDropItemSpawner>().Drop(objectSO.dropList, transform.position);
        gameObject.SetActive(false);
    }

    public virtual void Action()
    {
      
    }

    public void HighLight()
    {
        hightLightSelected.HightLight();
    }

    public void UnHighLight()
    {
        hightLightSelected.UnHightLight();
    }
    private void Update()
    {
        HPShowing();
    }

    protected virtual void HPShowing()
    {
        if (sliderHP == null) return;
        sliderHP.SetCurrentHP(currentHP);
        sliderHP.SetMaxHP(objectSO.hpMax);
    }
}
