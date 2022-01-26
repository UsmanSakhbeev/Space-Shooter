using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject DeathParticlePrefab = null;
    public bool ShouldDestroyOnDeath = true;
    [SerializeField] float _HealthPoints = 100f;
    public float HealthPoints
    {
        get
        {
            return _HealthPoints;
        }

        set
        {
            _HealthPoints = value;
            if (HealthPoints <= 0)
            {
                SendMessage("Die", SendMessageOptions.DontRequireReceiver);
                if (DeathParticlePrefab != null)
                {
                    Instantiate(DeathParticlePrefab, transform.position, transform.rotation);
                    StartCoroutine(DestroyDeathParticles());
                }

                if (ShouldDestroyOnDeath)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
    private IEnumerator DestroyDeathParticles()
    {
        yield return new WaitForSeconds(2);
        Destroy(DeathParticlePrefab);
    }
}
