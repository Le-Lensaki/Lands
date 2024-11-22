using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : LensakiMonoBehaviour
{
    public float FollowSpeed = 3.5f;
    public float yOffset = 1f;
    public Transform target;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        target = GameObject.Find("Player").transform;
    }
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y - yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}
