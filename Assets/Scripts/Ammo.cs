using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public float Damage = 100f;
    public float Lifetime = 5f;
    
    void OnEnable()
    {
        CancelInvoke();
        Invoke("Die",Lifetime);
    }

    void OnTriggerEnter(Collider Col)
    {
        Health H = Col.gameObject.GetComponent<Health>();
        if (H == null)
        {
            return;
        }
        H.HealthPoints -= Damage;
        Die();
    }

    void Die()
    {
        gameObject.SetActive(false);
    }
}
