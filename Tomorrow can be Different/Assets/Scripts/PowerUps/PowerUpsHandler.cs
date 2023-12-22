using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUpsHandler : MonoBehaviour
{
    private PlayerMovementAdvanced pm;
    public KeyCode KeyForPowerUp = KeyCode.O;
    private string powerName;
    
    void Start()
    {
        pm = GetComponent<PlayerMovementAdvanced>();
    }
    
    // If the player touches an object, check if its a PowerUp
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            // If it is a PowerUp, check which it is and turn on the power
            powerName = other.gameObject.name;

            if (powerName == "Dash Power Up")
            {
                pm.GetComponent<Dashing>().enabled = true;
            }
            else if (powerName == "DoubleJump")
            {
                pm.GetComponent<DoubleJump>().enabled = true;
            }
            
        }
        
    }
    
    
}
