using System.Collections.Generic;
using UnityEngine;

public class Plant : LensakiMonoBehaviour
{
    [SerializeField] protected int grownPlant;
    public int GrownPlant => grownPlant;

    [SerializeField] protected List<Sprite> spritesPlant;
    public List<Sprite> SpritesPlant => spritesPlant;

    [SerializeField] protected bool isHasSeed;
    public bool IsHasSeed => isHasSeed;

    protected override void OnEnable()
    {
        base.OnEnable();
        ResetPlant();
        //transform.GetComponent<SpriteRenderer>().sprite = spritesPlant[grownPlant];
    }

    public void ResetPlant()
    {
        grownPlant = 0;
        isHasSeed = false;
        spritesPlant = new List<Sprite>();
        transform.GetComponent<SpriteRenderer>().sprite = null;
    }    

    protected void Update()
    {
        //this.ChangeSpritePlant();
    }
    //public virtual void ChangeSpritePlant()
    //{
    //    switch (grownPlant)
    //    {
    //        case IDGrown.NoSeed:
                
    //            break;
    //        case IDGrown.Seed:
    //            transform.GetComponent<SpriteRenderer>().sprite = spritesPlant[1];
    //            break;
    //        case IDGrown.SmallPlant:
    //            transform.GetComponent<SpriteRenderer>().sprite = spritesPlant[2];
    //            break;
    //        case IDGrown.Plant:
    //            transform.GetComponent<SpriteRenderer>().sprite = spritesPlant[3];
    //            break;
    //        case IDGrown.PlantGrown:
    //            transform.GetComponent<SpriteRenderer>().sprite = spritesPlant[4];
    //            break;
    //        case IDGrown.BigPlant:
    //            transform.GetComponent<SpriteRenderer>().sprite = spritesPlant[5];
    //            break;
    //        case IDGrown.SuccessPlant:
    //            transform.GetComponent<SpriteRenderer>().sprite = spritesPlant[6];
    //            break;
    //    }

        
    //}
    public virtual void LoadInitialize(PlantSO plantSO,int grownPlant,bool isHasSeed)
    {
        SetSpritesPlant(plantSO.spriteGrown);
        ChangeGrownPlant(grownPlant);
        this.isHasSeed = isHasSeed;
    }


    public virtual void SetSpritesPlant(List<Sprite> listSprite)
    {
        this.spritesPlant = listSprite;
    }
    
    public virtual bool ChangeGrownPlant(int grown)
    {
        if (grown >= spritesPlant.Count) return false;
        grownPlant = grown;
        transform.GetComponent<SpriteRenderer>().sprite = spritesPlant[grownPlant];
        return true;
    }

    public virtual void SowSeed()
    {
        isHasSeed = true;
    }    
}
