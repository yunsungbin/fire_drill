using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    public float health;
    private float maxHealth = 100;

    private float GameTime;
    private float PlusFire = 50;

    public float attackDelay = 0f;
    public bool isDamaged = false;

    private void Awake()
    {
        health = maxHealth;
        GameTime = 0;
        PlusFire = 50;
    }

    private void Update()
    {
        if (health <= 0) Destroy(gameObject);
        if (maxHealth >= 150)
            return;

        GameTime += Time.deltaTime;

        if (GameTime >= PlusFire)
        {
            PlusFire += 50;
            maxHealth += 10;
        }

        if (isDamaged == true)
        {
            if (attackDelay < 0.5f)
            {
                attackDelay += Time.deltaTime;
            }
            else
            {
                isDamaged = false;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Item")
        {
            if (isDamaged == false)
            {
                health -= 50;
                attackDelay = 0f;
                isDamaged = true;
            }
        }
    }
}
