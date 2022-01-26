using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool MouseLook = true;
    public string HorzAxis = "Horizontal";
    public string VertAxis = "Vertical";
    public string FireAxis = "Fire1";
    public float ReloadDelay = 0.3f;
    public bool CanFire = true;
    public Transform[] TurretsTransforms;
    public float MaxSpeed = 5f;
    Rigidbody ThisBody = null;

    void Awake()
    {
        ThisBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float Horz = Input.GetAxis("Horizontal");
        float Vert = Input.GetAxis("Vertical");
        Vector3 MoveDirection = new Vector3(Horz, 0, Vert);
        ThisBody.AddForce(MoveDirection.normalized*MaxSpeed);
        ThisBody.velocity = new Vector3((Mathf.Clamp(ThisBody.velocity.x, -MaxSpeed,MaxSpeed)),Mathf.Clamp(ThisBody.velocity.y, -MaxSpeed, MaxSpeed),Mathf.Clamp(ThisBody.velocity.z, -MaxSpeed,MaxSpeed));
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && CanFire)
        {
            foreach (Transform T in TurretsTransforms)
            {
                AmmoManager.SpawnAmmo(T.position, T.rotation);
            }
            CanFire = false;
            Invoke("EnableFire", ReloadDelay);
        }
    }

    void EnableFire()
    {
        CanFire = true;
    }
}
