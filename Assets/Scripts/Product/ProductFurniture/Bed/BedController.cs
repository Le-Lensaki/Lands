using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedController : EntityController
{
    protected override void LoadComponents()
    {
        base.LoadComponents();
    }

    public override void Interact()
    {
        base.Interact();
        StartCoroutine(WakeUP());
    }

    IEnumerator WakeUP()
    {
        GameObject.Find("SceneTransition").GetComponent<Animator>().SetTrigger("End");
        yield return new WaitForSeconds(1);
        WorldTime.Instance.WakeUP();
        GameObject.Find("SceneTransition").GetComponent<Animator>().SetTrigger("Start");
        yield return new WaitForSeconds(1);
        PlayerController.Instance.ResetHPWhenSleep();


    }
}
