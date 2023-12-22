using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashing : MonoBehaviour
{
    [Header("References")] 
    public Rigidbody rb;
    public PlayerMovementAdvanced pm;
    private PowerUpsHandler DashKey;

    
    
    public float dashForce;
    public float dashDuration;
    public bool dashing = false;

    public string PowerUpName = "Dashing";
    
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
         
         Invoke(nameof(StopDash), dashDuration);
    }

    void StopDash()
    {
        if (dashing && !pm.grounded)
        {
            dashing = true;
        }
        else
        {
            dashing = false;
            
            // Turn off dash mechanic because it's a one time power up. Might change...
            gameObject.GetComponent<Dashing>().enabled = false;
        }

        
    }
}
