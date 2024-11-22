using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class Fade : LensakiMonoBehaviour
{
    [SerializeField] protected PolygonCollider2D col;

    [SerializeField] public SpriteRenderer mySpriteRenderer { get; set; }

    [SerializeField] private Color defaultColor;
    [SerializeField] private Color fadeColor;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPolygonCollider2D();
        this.LoadSpriteRenderer();
        this.LoadDefaultColor();
        this.LoadFadeColor();
    }
    #region LoadComponents
    protected virtual void LoadPolygonCollider2D()
    {
        if (col != null) return;
        col = transform.GetComponent<PolygonCollider2D>();
        col.isTrigger = true;

        Debug.Log(transform.name + ": LoadPolygonCollider2D", gameObject);

    }
    protected virtual void LoadSpriteRenderer()
    {
        if (mySpriteRenderer != null) return;
        mySpriteRenderer = GetComponent<SpriteRenderer>();

        Debug.Log(transform.name + ": LoadSpriteRenderer", gameObject);
    }

    protected virtual void LoadDefaultColor()
    {
        if(defaultColor != new Color(0,0,0,0)) return;
        defaultColor = this.mySpriteRenderer.color;

        Debug.Log(transform.name + ": LoadSpriteRenderer", gameObject);
    }

    protected virtual void LoadFadeColor()
    {
        if (fadeColor != new Color(0, 0, 0, 0)) return;
        fadeColor = defaultColor;
        fadeColor.a = 0.7f;
        Debug.Log(transform.name + ": LoadSpriteRenderer", gameObject);       
    }
    #endregion

    public void FadeOut()
    {
        
        if(transform.name != "Noah")
        {
            mySpriteRenderer.sortingOrder = 1;
        }    
        mySpriteRenderer.color = fadeColor;
    }
    public void FadeIn()
    {
        if (transform.name != "Noah")
        {
            mySpriteRenderer.sortingOrder = 0;
        }
        mySpriteRenderer.color = defaultColor;
        
    }
}
