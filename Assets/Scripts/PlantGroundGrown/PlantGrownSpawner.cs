using Assets.Scripts.Item.IDItem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrownSpawner : Spawner
{
    [SerializeField] protected List<GameObject> plantSpawn;
    public List<GameObject> PlantSpawn => plantSpawn;
    protected override void Awake()
    {
        base.Awake();
        plantSpawn = new List<GameObject>();
    }

    public virtual void Hoe(Vector3 pos)
    {
        Transform itemDrop = this.Spawn("Farm", pos);
        if (itemDrop == null) return;

        itemDrop.gameObject.SetActive(true);
        plantSpawn.Add(itemDrop.gameObject);
    }

    public ListFarmSave CreateListFarmSaveData()
    {
        ListFarmSave listFarmSave = new ListFarmSave();

        foreach (var item in plantSpawn)
        {
            listFarmSave.listFarmSaveData.Add(item.GetComponent<PlantGrownController>().GetFarmSaveData());
        }

        return listFarmSave;
    }
    public void LoadListFarmSaveData(ListFarmSave listFarmSave)
    {
        for (int i = 0; i < listFarmSave.listFarmSaveData.Count; i++)
        {
            Hoe(listFarmSave.listFarmSaveData[i].position);
            plantSpawn[i].GetComponent<PlantGrownController>().SetFarmSaveData(listFarmSave.listFarmSaveData[i]);
        }
    }

}
