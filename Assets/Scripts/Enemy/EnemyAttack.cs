using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAttack : MonoBehaviour
{
    #region 
    public Transform rayCast;
    public LayerMask rayCastMask;
    public float rayCastLength;

    public float attackDistance; //minimum distance for attack

    public float timer; //Timer for cooldown between attacks

    public int damage;
    public AIPath aiPath;

    #endregion

    #region Private variables
    private RaycastHit2D hit;

    private GameObject target;

    [SerializeField]
    private Animator animator;

    private float distance; //Store the distance b/w enemy and player

    private bool attackMode;

    private bool cooling;  //Check if Enemy is cooling after attack

    private bool inRange;  //Check if player is in range

    private float intTimer;  


    #endregion

    // Start is called before the first frame update
    void Awake()
    {
        intTimer = timer; //Store the initial value of timer
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inRange)
        {
            hit = Physics2D.Raycast(rayCast.position,Vector2.left,rayCastLength, rayCastMask);
            RaycastDebugger();

            //When Player is detected

            if(hit.collider != null)
            {
                EnemyLogic();
            }
            else if(hit.collider == null)
            {
                inRange = false;
            }

            if(inRange == false)
            {
                //anim.SetBool("canWalk",false)
                StopAttack();
            }


        }
    }

    void OnTriggerEnter2D(Collider2D trig) {
       if(trig.gameObject.tag == "Player")
       {
           target = trig.gameObject;
           TriggerCooling();
           inRange = true;
           
       }
    }

    void RaycastDebugger()
    {
        if(distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, new Vector2(target.transform.position.x - rayCast.position.x,target.transform.position.y - rayCast.position.y) * rayCastLength, Color.yellow);
        }
        else if (attackDistance > distance)
        {
            Debug.DrawRay(rayCast.position,new Vector2(target.transform.position.x - rayCast.position.x,target.transform.position.y - rayCast.position.y) * rayCastLength, Color.red);
        }
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);

        if(distance > attackDistance)
        {
            Move();
            StopAttack();
        }
        else if(attackDistance >= distance && cooling == false){
            Attack();
        }

        if(cooling){
            Cooldown();
            //anim.SetBool("Attack",false);
        }
    }

    void Move()
    {
        // not for our use case 
        //it is handled by ai pathfinder
        /*
        anim.SetBool("canWalk",true);
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Skel_attack"))
        {
            Vector2 targetPosition = new Vector2(target.transform.position.x, transform.position.y);
            transform.position = Vecotr2.MoveTowards(transform.position,targetPosition,moveSpeed * Time.deltaTime);
        }
        */
    }

    void Attack()
    {
        timer = intTimer; //Reset timer when player enter attack range 
        attackMode = true;//To check if enemy can still attack or not
        //log attack
        Debug.Log("AttackPlayer");
        animator.SetBool("Attacking",true);
        TriggerCooling();
        //deal damage
        target.GetComponent<PlayerHealth>().getDamage(damage);

        //anim section

        //animator.SetBool("Walk",false);
        //animator.SetBool("Attack",true);
        
    }

    void StopAttack()
    {
        cooling = false;
        attackMode = false;
        animator.SetBool("Attacking",false);

    }

    void TriggerCooling()
    {
        cooling = true;
    }

    void Cooldown()
    {
        timer -= Time.deltaTime;

        if(timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }
}
