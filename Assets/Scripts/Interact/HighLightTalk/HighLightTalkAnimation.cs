using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class HighLightTalkAnimation : LensakiMonoBehaviour
{
    protected Animator anim;

    [SerializeField] protected SpriteRenderer spriteRendererTagMission;

    [SerializeField] protected Sprite tagMission;
    [SerializeField] protected Sprite tagMissionCompleted;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
        this.LoadSpriteRendererTagMission();

        this.LoadTagMissionSprite();
        this.LoadTagMissionCompletedSprite();
    }
    #region LoadComponents
    protected virtual void LoadAnimator()
    {
        if (anim != null) return;

        anim = gameObject.GetComponent<Animator>();
        Debug.Log(transform.name + " : LoadAnimator", gameObject);
    }

    protected virtual void LoadSpriteRendererTagMission()
    {
        if (spriteRendererTagMission != null) return;

        spriteRendererTagMission = transform.GetChild(0).GetComponent<SpriteRenderer>();
        Debug.Log(transform.name + " : LoadSpriteRendererTagMission", gameObject);
    }

    protected virtual void LoadTagMissionSprite()
    {
        if (this.tagMission != null) return;
        string resPath = "Emoji/" + "Emoji spritesheet";
        string nameSprite = "Emoji_TagMission";
        Sprite[] sprites = Resources.LoadAll<Sprite>(resPath);
        foreach (var item in sprites)
        {
            if (item.name == nameSprite) this.tagMission = item;
        }
        Debug.LogWarning(transform.name + ": LoadTagMissionSprite " + resPath, gameObject);
    }
    protected virtual void LoadTagMissionCompletedSprite()
    {
        if (this.tagMissionCompleted != null) return;
        string resPath = "Emoji/" + "Emoji spritesheet";
        string nameSprite = "Emoji_TagMissionCompleted";
        Sprite[] sprites = Resources.LoadAll<Sprite>(resPath);
        foreach (var item in sprites)
        {
            if (item.name == nameSprite) this.tagMissionCompleted = item;
        }
        Debug.LogWarning(transform.name + ": LoadTagMissionCompletedSprite " + resPath, gameObject);
    }
    #endregion



}
