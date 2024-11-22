using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCloseInventory : BaseButton
{
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDefaultSprite();
        this.LoadPressedSprite();
        this.LoadButton();
    }

    #region LoadComponents
    protected virtual void LoadDefaultSprite()
    {
        if (this.defaultSprite != null) return;
        string resPath = "ButtonUI/" + "Icon Buttons Spritesheet";
        string nameSprite = "BtnEnable_Close";
        Sprite[] sprites = Resources.LoadAll<Sprite>(resPath);
        foreach (var item in sprites)
        {
            if (item.name == nameSprite) this.defaultSprite = item;
        }
        Debug.LogWarning(transform.name + ": LoadDefaultSprite " + resPath, gameObject);
    }
    protected virtual void LoadPressedSprite()
    {
        if (this.pressSprite != null) return;
        string resPath = "ButtonUI/" + "Icon Buttons Spritesheet";
        string nameSprite = "BtnDisable_Close";
        Sprite[] sprites = Resources.LoadAll<Sprite>(resPath);
        foreach (var item in sprites)
        {
            if (item.name == nameSprite) this.pressSprite = item;
        }
        Debug.LogWarning(transform.name + ": LoadPressedSprite " + resPath, gameObject);
    }

    protected virtual void LoadButton()
    {
        if (button != null) return;
        button = GetComponent<Button>();
        button.transition = Selectable.Transition.SpriteSwap;
        SpriteState stateSpriteButton = new SpriteState();
        stateSpriteButton.pressedSprite = pressSprite;
        stateSpriteButton.disabledSprite = defaultSprite;
        button.spriteState = stateSpriteButton;

        Debug.Log(transform.name + ": LoadButton", gameObject);
    }
    #endregion
    protected override void OnClick()
    {
        UIManagerSceneMainGame.Instance.OpenCloseInventory();
    }

}
