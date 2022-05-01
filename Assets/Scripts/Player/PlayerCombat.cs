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



    // Start is called before the first frame update
    void Start()
    {
        
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
        }
    }

    void OnDrawGizmosSelected() 
    {
        if(attackPoint == null){
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
