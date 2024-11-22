using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FadeRoof : LensakiMonoBehaviour
{
    [SerializeField] protected Collider2D col;

    [SerializeField] public Tilemap tilemap { get; set; }

    [SerializeField] private Color defaultColor;
    [SerializeField] private Color fadeColor;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider2D();
        this.LoadTilemap();
        this.LoadDefaultColor();
        this.LoadFadeColor();
    }
    #region LoadComponents
    protected virtual void LoadCollider2D()
    {
        if (col != null) return;
        col = transform.GetComponent<Collider2D>();
        col.isTrigger = true;

        Debug.Log(transform.name + ": LoadCollider2D", gameObject);

    }
    protected virtual void LoadTilemap()
    {
        if (tilemap != null) return;
        tilemap = GetComponent<Tilemap>();

        Debug.Log(transform.name + ": LoadTilemap", gameObject);
    }

    protected virtual void LoadDefaultColor()
    {
        if(defaultColor != new Color(0,0,0,0)) return;
        defaultColor = this.tilemap.color;

        Debug.Log(transform.name + ": LoadSpriteRenderer", gameObject);
    }

    protected virtual void LoadFadeColor()
    {
        if (fadeColor != new Color(0, 0, 0, 0)) return;
        fadeColor = defaultColor;
        fadeColor.a = 0f;
        Debug.Log(transform.name + ": LoadSpriteRenderer", gameObject);       
    }
    #endregion

    public void FadeOut()
    {
        tilemap.color = fadeColor;
    }
    public void FadeIn()
    {
        tilemap.color = defaultColor;
    }
}
