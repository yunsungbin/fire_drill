using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    public float health;
    private float maxHealth = 100;

    private float GameTime;
    private float PlusFire = 50;

    private void Awake()
    {
        health = maxHealth;
        GameTime = 0;
        PlusFire = 50;
    }

    private void Update()
    {
        if (maxHealth >= 150)
            return;

        GameTime += Time.deltaTime;

        if (GameTime >= PlusFire)
        {
            PlusFire += 50;
            maxHealth += 10;
        }
    }
}
