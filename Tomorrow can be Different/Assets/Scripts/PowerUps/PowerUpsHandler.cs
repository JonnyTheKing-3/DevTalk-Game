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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            powerName = other.gameObject.name;
            Debug.Log("power name: " + powerName);

            if (powerName == "Dash")
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
