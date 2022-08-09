using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;

    public int health;

    public bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        if(dead)
        {
            Destroy(gameObject);
        }
    }

    public void getDamage(int damage)
    {
        health = health - damage;
        if(health <= 0)
        {
            //kill player 
            dead = true;
        }
    }

    
}
