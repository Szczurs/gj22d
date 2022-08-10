using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb = null;

    [SerializeField] private int damageToDeal = 20;
    [SerializeField] private float launchForce = 2f;

    [SerializeField] private float destroyAfterSeconds = 1f;
    [SerializeField] private GameObject player;
    private PlayerHealth playerHealth;
    public void Setup()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.velocity = transform.forward * launchForce;
        rb.velocity = transform.TransformDirection(new Vector3(0, -launchForce, 0));
        rb.AddForce(transform.up * launchForce,ForceMode2D.Impulse);
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }
    // Start is called before the first frame update
    /*
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(0.0f, -launchForce, 0.0f);
        rb.velocity = transform.forward * launchForce;
        
    }
    */
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        Destroy(gameObject,destroyAfterSeconds);
    }
    private void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * launchForce);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            if (other.TryGetComponent<EnemyHealth>(out EnemyHealth health))
            {
                health.getTimeDamage(damageToDeal);
                playerHealth.addTime(damageToDeal);

            }


        }
        
    }
    private void OnCollisionEnter2D(Collider2D other)
    {
        if (other.tag == "Obstacle")
        {
            DestroySelf();
        }
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame

}
