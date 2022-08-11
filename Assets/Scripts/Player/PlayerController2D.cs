using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    public Vector2 movement;

    private float activeMoveSpeed;
    public float dashSpeed;

    public float dashLength = 5f;
    public float dashCooldown = 1f;

    public float dashCounter;
    private float dashCoolCounter;

    [SerializeField]
    private PlayerHealth playerHealth;

    [SerializeField]
    private Animator animator;

    private float timeValueRatio;



    // Start is called before the first frame update
    void Start()
    {
        activeMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        timeValueRatio = (float)playerHealth.timeValue / 100f;
        //input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize();

        //var velocity = Vector3.forward * Time.deltaTime * Input.GetAxis("Vertical") * moveSpeed;

        rb.velocity = movement * activeMoveSpeed * timeValueRatio;
        
     
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.magnitude));
    
      


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("spa");
            if (dashCoolCounter >= 0 && dashCooldown >= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
                Debug.Log("spa1");

            }
        }

        if (dashCounter > 0)
        {
            Debug.Log("1");
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                Debug.Log("2");
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCooldown;
            }
        }

        if (dashCoolCounter < 0)
        {
            Debug.Log("3");
            dashCoolCounter -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        //movement
        //rb.MovePosition(rb.position + movement * activeMoveSpeed * Time.fixedDeltaTime);
    }
}
