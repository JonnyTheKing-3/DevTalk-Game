using UnityEngine;

public class PauseManager : MonoBehaviour
{
    /*
     * Still need to pause the player Inputs. I can do it with like a boolean or something.
     * I'll do that later. Don't wanna overcomplicate things
     * Later I can make more Pause functions but for now, this will do
     */
    
    
    private bool isPaused = false;
    
    [Header("Pause settings")]
    [SerializeField] private KeyCode pauseKey = KeyCode.Escape;
    [SerializeField] private GameObject PausePic;
    

    
    void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }
    
    public void PauseGame()
    {
        Time.timeScale = 0f; // Stop time
        PausePic.SetActive(true); // Display pause menu
        
        // Later we'll add a stop to other things if needed and undo them in resume game
    }

    public void ResumeGame()
    {
        Debug.Log("Resume button pressed");
        Time.timeScale = 1f; // Resume time
        PausePic.SetActive(false); // Stop displaying pause menu
    }
}

