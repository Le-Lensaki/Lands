using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockSaveController : EntityController
{
    public override void Interact()
    {
        base.Interact();
        UIManagerSceneMainGame.Instance.OpenUISaveGame();
    }
}
