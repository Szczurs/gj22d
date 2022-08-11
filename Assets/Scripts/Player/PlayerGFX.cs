using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGFX : MonoBehaviour
{
    Vector2 movement;

    [SerializeField] private GameObject playerGFX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x >= 0.01f)
        {
            playerGFX.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (movement.x <= -0.01f)
        {
            playerGFX.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}
