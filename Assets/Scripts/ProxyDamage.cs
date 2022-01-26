using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProxyDamage : MonoBehaviour
{
    public float Damage = 10f;
    void OnTriggerStay(Collider Col)
    {
        PlayerHealth H = Col.gameObject.GetComponent<PlayerHealth>();
        if(H==null)
            return;
        H.HealthPoints -= Damage;
        this.gameObject.GetComponent<Health>().HealthPoints = 0;
    }
}
