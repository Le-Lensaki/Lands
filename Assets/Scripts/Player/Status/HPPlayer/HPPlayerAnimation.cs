using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HPPlayerAnimation : LensakiMonoBehaviour
{
    [SerializeField] protected Image imageHeart_1;
    [SerializeField] protected Image imageHeart_2;
    [SerializeField] protected Image imageHeart_3;
    [SerializeField] protected List<Image> listImageHeart;
    [SerializeField] protected TMP_Text textHP;


    [SerializeField] protected Sprite heartNull;
    [SerializeField] protected Sprite heartHalf;
    [SerializeField] protected Sprite heartFull;

    

    protected override void LoadComponents()
    {
        base.LoadComponents();

        this.LoadImageHeart_1();
        this.LoadImageHeart_2();
        this.LoadImageHeart_3();

        this.LoadTextHP();

        this.LoadHeartNulltSprite();
        this.LoadHeartHalftSprite();
        this.LoadHeartFulltSprite();
        
    }
    #region LoadComponents
    protected virtual void LoadImageHeart_1()
    {
        if (imageHeart_1 != null) return;

        imageHeart_1 = transform.GetChild(0).GetComponent<Image>();
        listImageHeart.Add(imageHeart_1);
        Debug.Log(transform.name + ": LoadImageHeart_1", gameObject);
    }
    protected virtual void LoadImageHeart_2()
    {
        if (imageHeart_2 != null) return;

        imageHeart_2 = transform.GetChild(1).GetComponent<Image>();
        listImageHeart.Add(imageHeart_2);
        Debug.Log(transform.name + ": LoadImageHeart_2", gameObject);
    }
    protected virtual void LoadImageHeart_3()
    {
        if (imageHeart_3 != null) return;

        imageHeart_3 = transform.GetChild(2).GetComponent<Image>();
        listImageHeart.Add(imageHeart_3);
        Debug.Log(transform.name + ": LoadImageHeart_3", gameObject);
    }
    protected virtual void LoadTextHP()
    {
        if (textHP != null) return;

        textHP = transform.GetChild(3).GetComponent<TMP_Text>();
        Debug.Log(transform.name + ": LoadTextHP", gameObject);
    }



    protected virtual void LoadHeartNulltSprite()
    {
        if (this.heartNull != null) return;
        string resPath = "Status/" + "Hearts";
        string nameSprite = "HeartNull";
        Sprite[] sprites = Resources.LoadAll<Sprite>(resPath);
        foreach (var item in sprites)
        {
            if (item.name == nameSprite) this.heartNull = item;
        }
        Debug.LogWarning(transform.name + ": LoadHeartNulltSprite " + resPath, gameObject);
    }

    protected virtual void LoadHeartHalftSprite()
    {
        if (this.heartHalf != null) return;
        string resPath = "Status/" + "Hearts";
        string nameSprite = "HeartHalf";
        Sprite[] sprites = Resources.LoadAll<Sprite>(resPath);
        foreach (var item in sprites)
        {
            if (item.name == nameSprite) this.heartHalf = item;
        }
        Debug.LogWarning(transform.name + ": LoadHeartHalftSprite " + resPath, gameObject);
    }

    protected virtual void LoadHeartFulltSprite()
    {
        if (this.heartFull != null) return;
        string resPath = "Status/" + "Hearts";
        string nameSprite = "HeartFull";
        Sprite[] sprites = Resources.LoadAll<Sprite>(resPath);
        foreach (var item in sprites)
        {
            if (item.name == nameSprite) this.heartFull = item;
        }
        Debug.LogWarning(transform.name + ": LoadHeartFulltSprite " + resPath, gameObject);
    }
    #endregion

    

    public virtual void UpdateHPBar(int currentHP,int maxHP)
    {
        textHP.text = currentHP.ToString()+"/"+maxHP.ToString();
        UpdateHear(currentHP, maxHP);
    }
    protected virtual void UpdateHear(int currentHP, int maxHP)
    {
        float hp = (float) currentHP / maxHP * 3;
        int fullHearts = (int)Math.Floor(hp);
        bool hasHalfHeart = (hp - fullHearts) >= 0.5f;

        imageHeart_1.sprite = fullHearts >= 1 ? heartFull : (hasHalfHeart && fullHearts == 0 ? heartHalf : heartNull);

        imageHeart_2.sprite = fullHearts >= 2 ? heartFull : (hasHalfHeart && fullHearts == 1 ? heartHalf : heartNull);

        imageHeart_3.sprite = fullHearts >= 3 ? heartFull : (hasHalfHeart && fullHearts == 2 ? heartHalf : heartNull);
    }
}
