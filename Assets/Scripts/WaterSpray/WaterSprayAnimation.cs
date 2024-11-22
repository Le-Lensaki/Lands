using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class WaterSprayAnimation : LensakiMonoBehaviour
{
    [SerializeField] protected Animator anim;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
    }

    protected virtual void LoadAnimator()
    {
        if (anim != null) return;
        this.anim = GetComponent<Animator>();

        Debug.Log(transform.name + ": LoadAnimator", gameObject);
    }

    public void Spray(Vector2 vector)
    {
        if (vector.x > 0)
        {
            Vector3 vector3 = new Vector3(PlayerController.Instance.transform.position.x + 1.4f, PlayerController.Instance.transform.position.y - 0.33f, 0);
            transform.position = vector3;
        }
        else if (vector.x < 0)
        {
            Vector3 vector3 = new Vector3(PlayerController.Instance.transform.position.x - 1.4f, PlayerController.Instance.transform.position.y - 0.33f, 0);
            transform.position = vector3;
        }
        else if (vector.y > 0)
        {
            Vector3 vector3 = new Vector3(PlayerController.Instance.transform.position.x + 0.3f, PlayerController.Instance.transform.position.y + 0.4f, 0);
            transform.position = vector3;
        }
        else if (vector.y < 0)
        {
            Vector3 vector3 = new Vector3(PlayerController.Instance.transform.position.x - 0.3f, PlayerController.Instance.transform.position.y - 0.6f, 0);
            transform.position = vector3;
        }


        anim.SetFloat("x", vector.x);
        anim.SetFloat("y", vector.y);
        anim.SetBool("Spray", true);
    }
    public void StopSpray()
    {
        anim.SetBool("Spray", false);
    }

}
