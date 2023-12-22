using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashing : MonoBehaviour
{
    [Header("References")] 
    private Rigidbody rb;
    private PlayerMovementAdvanced pm;
    private PowerUpsHandler DashKey;
    
    [Header("Dash Settings")]
    public float dashForce;
    public float dashDuration;
    public bool dashing = false;

    public bool OneTimeUse = true;
    
    // Direction to dash to
    private Vector3 dashDirection;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<PlayerMovementAdvanced>();
        DashKey = GetComponent<PowerUpsHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        // When to Dash
        if (Input.GetKeyDown(DashKey.KeyForPowerUp))
        {
            dashing = true;
        }

        if (dashing)
        {
            Dash();
        }
    }

    void Dash()
    {
         // If the player is on a slope, make the dash point in the appropriate direction
         if (pm.OnSlope() && !pm.exitingSlope)
         {
             rb.AddForce(pm.GetSlopeMoveDirection(pm.moveDirection) * dashForce, ForceMode.Force);
        
             if (rb.velocity.y > 0)
                 rb.AddForce(Vector3.down * 80f, ForceMode.Force);
         }
         else // if not on slope, do dash normally
         {
            rb.AddForce(pm.moveDirection * dashForce, ForceMode.Force); 
         }
         
         // Stop dash after dashDuration seconds pass
         Invoke(nameof(StopDash), dashDuration);
    }

    void StopDash()
    {
        /*
         * If stop dash is called, but the player is still in the air (in other words
         * if the player dashed and is in the air by the time the dash is supposed to stop),
         * keep dashing until we hit the ground
         */
        if (dashing && !pm.grounded)
        {
            dashing = true;
        }
        else // Otherwise, stop the dash
        {
            dashing = false;

            if (OneTimeUse)
            {
                // Turn off mechanic if it's a one time power up
                gameObject.GetComponent<Dashing>().enabled = false;
            }
        }

        
    }
}
