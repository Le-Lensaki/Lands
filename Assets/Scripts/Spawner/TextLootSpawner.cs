using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextLootSpawner : Spawner
{

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHolderTextLoot();
    }

    protected virtual void LoadHolderTextLoot()
    {
        if (this.holder != null) return;
        this.holder = GameObject.Find("HolderTextLoot").transform;
        Debug.Log(transform.name + ": LoadHolderTextLoot", gameObject);
    }    

    public virtual void Loot(Item item, Vector3 pos)
    {
        Transform itemDrop = this.Spawn("SpawnText", pos);
        if (itemDrop == null) return;
        itemDrop.localScale = new Vector3(1f,1f,1f);
        itemDrop.GetChild(0).GetComponent<Image>().sprite = item.Icon;
        itemDrop.gameObject.SetActive(true);
    }
}
