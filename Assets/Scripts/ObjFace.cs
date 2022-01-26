using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjFace : MonoBehaviour
{
    public Transform ObjToFollow = null;
    public bool FollowPlayer = false;
    bool Rotate = true;
    void Awake()
    {
        if(!FollowPlayer)
            return;
        GameObject PlayerObj = GameObject.FindGameObjectWithTag("Player");
        if (PlayerObj != null)
        {
            ObjToFollow = PlayerObj.transform;
        }
    }

    void Update()
    {
        if (ObjToFollow == null)
        {
            return;
        }
        if (transform.position.z < 0)
        {
            Rotate = false;
        }
        Vector3 DirToObject = ObjToFollow.position - transform.position;
        if ((DirToObject != Vector3.zero)&& Rotate)
        {
            transform.localRotation = Quaternion.LookRotation(DirToObject.normalized,Vector3.up);
        }
    }
}
