using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//#define USE_ANIMATOR 0
public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;

    public Transform crosshair;

    public float attackRange = 0.5f;

    public LayerMask enemyLayers;

    public int damage = 10;

    public int timeDamage = 10;

    public float attackCooldown = 2;

    public float timeAttackCooldown = 2;

    bool cooling;

    bool timeAttackCooling;

    [SerializeField]
    private Transform timeBulletPrefab;

    [SerializeField]
    private GameObject timeBulletSpawnPosition;

    private float intAttackCooldown;
    private float intTimeAttackCooldown;

    [SerializeField]
    private PlayerHealth playerHealth;




    // Start is called before the first frame update
    void Start()
    {
        intAttackCooldown = attackCooldown;
        intTimeAttackCooldown = timeAttackCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        //rotate attack pivot
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        crosshair.transform.rotation = rotation;

        if(Input.GetKeyDown(KeyCode.G))
        {
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            TimeAttack();
        }
        else if (cooling)
        {
            Cooldown();
        }
    }
    void TimeAttack()
    {
        //Play an attack animation
        //animator.SetTrigger("Attack");
        //Detect enemies in range of attack
        /*
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //Damage them 

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit time " + enemy.name);
            enemy.GetComponent<EnemyHealth>().getTimeDamage(damage);
            playerHealth.addTime(damage);
            TriggerTimeAttackCooling();
        }
        */
        Transform bulletTransform = Instantiate(timeBulletPrefab, timeBulletSpawnPosition.transform.position, Quaternion.identity);
        Vector3 shootDir = 
        bulletTransform.GetComponent<Bullet>().Setup();
        TriggerTimeAttackCooling();
    }
    void Attack()
    {
        //Play an attack animation
        //animator.SetTrigger("Attack");
        //Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayers);
        //Damage them 

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<EnemyHealth>().getDamage(damage);
            TriggerCooling();
        }
    }

    void OnDrawGizmosSelected() 
    {
        if(attackPoint == null){
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    void TriggerCooling()
    {
        cooling = true;
    }

    void TriggerTimeAttackCooling()
    {
        timeAttackCooling = true;
    }

    void Cooldown()
    {
        attackCooldown -= Time.deltaTime;
        timeAttackCooldown -= Time.deltaTime;

        if (attackCooldown <= 0 && cooling)
        {
            cooling = false;
            attackCooldown = intAttackCooldown;
        }

        if (timeAttackCooldown <= 0 && timeAttackCooling)
        {
            timeAttackCooling = false;
            timeAttackCooldown = intTimeAttackCooldown;
        }
    }

}
