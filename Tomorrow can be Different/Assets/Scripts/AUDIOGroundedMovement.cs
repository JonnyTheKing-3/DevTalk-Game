using UnityEngine;

/// <summary>
/// This script is in charge of the logic for all sounds regarding grounded movement (walking, running, hoverboard)
/// </summary>
///
/// TODO: Make logic for hoverboard
public class AUDIOGroundedMovement : MonoBehaviour
{
    [Header("REFERENCES")] 
    public PlayerMovementAdvanced pma;

    // How fast the audio clip should play for walking, running, and hoverboard
    [Header("AUDIO PACING")]
    public float walkRate;
    public float runRate;
    private float currentRate;
    
    // Variable to keep track of the last position
    private Vector3 lastStep;

    private void Start()
    {
        pma = GetComponent<PlayerMovementAdvanced>();
    }

    void Update()
    {
        // distance between the last position and the current position
        float distance = Vector3.Distance(transform.position, lastStep);

        // Logic to know which rate to use depending on whether the player is walking or running
        switch (pma.state)
        {
            case PlayerMovementAdvanced.MovementState.walking: 
                currentRate = walkRate;
                break;
            case PlayerMovementAdvanced.MovementState.sprinting: 
                currentRate = runRate; 
                break;
         }

         // if the distance is greater/equal to the step rate, play step sound
         if (distance >= currentRate)
         {
             // REPLACE WITH AUDIO CLIP
             Debug.Log("footstep!");
             // reset the last step
             lastStep = transform.position;
         }
    }
}
