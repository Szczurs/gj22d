using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;

    public int health;

    public int timeValue = 100;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0 || timeValue <= 0)
        {
            //kill yourself
            Destroy(gameObject);
        }
    }

    public void getDamage(int damage)
    {
        health = health - damage;
    }

    public void getTimeDamage(int damage)
    {
        timeValue = timeValue - damage;
    }
}
