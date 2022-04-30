using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage = 10;

    public Transform crosshair;

    private float rayCastLength = 5;

    public Camera cam;
    Vector2 mousePosition;

    public Rigidbody2D rb;

    private RaycastHit2D hit;


    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*Debug.DrawRay(transform.position, new Vector2(Input.mousePosition.x - transform.position.x,Input.mousePosition.y - transform.position.y) * rayCastLength, Color.blue);
       if(Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit;
        }
        */
        //mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        crosshair.transform.rotation = rotation;
    }

    void FixedUpdate() 
    {
        /*
        //Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        Vector2 lookDir = mousePosition - rb.position;
        float angle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        */

    }
}
