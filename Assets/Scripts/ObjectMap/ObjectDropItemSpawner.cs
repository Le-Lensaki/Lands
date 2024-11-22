using Assets.Scripts.Item.IDItem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDropItemSpawner : Spawner
{
    protected float dropRadius = 3f;
    protected float avoidRadius = 1.2f;

    [SerializeField] protected Vector3 posAxe;

    [SerializeField] protected Vector3 posHoe;
    [SerializeField] protected Vector3 posSpray;

    public virtual void Drop(List<Item> dropList, Vector3 pos)
    {
        for (int i = 0; i < dropList.Count; i++)
        {
            IDItem idItem = dropList[i].GetId;
            Transform itemDrop = this.Spawn(idItem.ToString(), GetRandomDropPosition(pos));
            if (itemDrop == null) return;
            itemDrop.gameObject.SetActive(true);
        }
    }

    public virtual void DropByNameItem(string nameItem, Vector3 pos)
    {
        Transform itemDrop = this.Spawn(nameItem,GetRandomDropPosition(pos));
        if (itemDrop == null) return;
        itemDrop.gameObject.SetActive(true);
    }

    public virtual void DropNewGame()
    {
        Transform itemDrop = this.Spawn("Axe", posAxe);
        if (itemDrop == null) return;
        itemDrop.gameObject.SetActive(true);

        itemDrop = this.Spawn("Hoe", posHoe);
        if (itemDrop == null) return;
        itemDrop.gameObject.SetActive(true);

        //itemDrop = this.Spawn("SprayWater", posSpray);
        //if (itemDrop == null) return;
        //itemDrop.gameObject.SetActive(true);
    }    

    private Vector3 GetRandomDropPosition(Vector3 pos)
    {
        Vector3 dropPoint = pos; 
        Vector3 randomPosition;

        do
        {
            float randomAngle = Random.Range(0f, Mathf.PI * 2);  
            float randomDistance = Random.Range(0f, dropRadius); 
            randomPosition = dropPoint + new Vector3(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle),0) * randomDistance;

        } while (Vector3.Distance(randomPosition, PlayerController.Instance.transform.position) < avoidRadius);

        return randomPosition;
    }
}
