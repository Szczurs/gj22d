using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{
    public float maxHealth = 100;

    public float health;

    public int damage = 10;

    public float cooldown = 2;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void dealDamage()
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<PlayerHealth>().getDamage(damage);
    }
}
