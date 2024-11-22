using Assets.Scripts.Item.IDItem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item" ,menuName = "SO/Item")]
public class Item : ScriptableObject
{
    [SerializeField] protected IDItem id = IDItem.NoItem;
    [SerializeField] protected TagName tagName = TagName.NoTag;
    [SerializeField] protected string nameItem;
    [SerializeField] protected int foodStat;
    [SerializeField] protected string discription;
    [SerializeField] protected PlantSO seedPlant;
    [SerializeField] protected Sprite icon;

    public IDItem GetId { get { return id; } }
    public TagName TagName { get { return tagName; } }

    public string GetName { get { return nameItem; } }
    public int FoodStat { get { return foodStat; } }
   
    public string GetDiscription { get { return discription; } }

    public PlantSO SeedPlant { get { return seedPlant; } }

    public Sprite Icon { get { return icon; } }
}
