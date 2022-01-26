using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    void Update()
    {
        if (HealthPoints <= 0)
        {
            GameController.GameOver();
        }
    }
}
