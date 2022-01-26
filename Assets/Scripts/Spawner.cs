using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Spawner : MonoBehaviour
{

    public float EnemyInterval = 5f;
    public float AsteroidInterval = 2f;
    public GameObject[] prefabs;
    public int[] EnemyRespawnInterval = {4,2};
    public int[] EnemyCount = {5, 100};
    bool IsLevelStarted = false;
    public int level { get; private set; } = 0;
    public int Counter = 0;
    Transform Origin = null;

    void Awake()
    {
        Origin = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if (!IsLevelStarted)
        {
            InvokeRepeating("Spawn1", 1f, EnemyRespawnInterval[level]);
            IsLevelStarted = true;
        }
    }

    void Spawn1()
    {
        if (Origin == null)
        {
            return;
        }
        Random rnd = new Random();
        int posX = rnd.Next(-5, 5);
        Vector3 SpawnPos = new Vector3(posX, 0.1f, 5);
        Instantiate(prefabs[level], SpawnPos, Quaternion.LookRotation(Vector3.back));
        Counter++;
        if (Counter >= EnemyCount[level])
        {
            level = 1;
            Counter = 0;
            IsLevelStarted = false;
            CancelInvoke();
        }
    }
}
