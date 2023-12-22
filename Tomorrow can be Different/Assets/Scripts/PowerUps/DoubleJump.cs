using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    private PlayerMovementAdvanced pm;
    private PowerUpsHandler DJumpKey;
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        pm = GetComponent<PlayerMovementAdvanced>();
        rb = GetComponent<Rigidbody>();
        DJumpKey = GetComponent<PowerUpsHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(DJumpKey.KeyForPowerUp))
        {
            // Do a type of jump
            gameObject.GetComponent<DoubleJump>().enabled = false;
        }
    }
}
