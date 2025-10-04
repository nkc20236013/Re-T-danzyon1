using NUnit.Framework.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed;
    float hAxis;
    float vAxis;
    bool wDoen;

    Vector3 moveVec;

    Animator anim;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();   
    }

    
    void Update()
    {
        hAxis = Input.GetAxisRaw("Horizonntal");
        vAxis = Input.GetAxisRaw("Vertical");
        wDoen = Input.GetButton("Walk");
        
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += moveVec * speed * (wDoen ? 0.3f:1f) * Time.deltaTime;

        anim.SetBool("isRun", moveVec != Vector3.zero);
        anim.SetBool("isWalk", wDoen);


        transform.LookAt(transform.position + moveVec);
    }
}
