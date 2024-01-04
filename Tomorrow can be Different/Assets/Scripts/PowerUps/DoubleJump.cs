using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    [Header("Jump attributes")] 
    public float jumpForce;
    [Space] 
    public bool OneTimeUse = false;
    
    [Header("References")]
    private PlayerMovementAdvanced pm;
    private PowerUpsHandler DJumpKey;
    private Rigidbody rb;
    
    

    void Start()
    {
        pm = GetComponent<PlayerMovementAdvanced>();
        rb = GetComponent<Rigidbody>();
        DJumpKey = GetComponent<PowerUpsHandler>();
    }
    void FixedUpdate()
    {
        if (Input.GetKeyDown(DJumpKey.KeyForPowerUp))
        {
            // Do a type of jump
            rb.velocity += Vector3.up * jumpForce;

            // disable if it's only a one time use
            if (OneTimeUse)
            {
                gameObject.GetComponent<DoubleJump>().enabled = false;
            }
        }
    }
}
