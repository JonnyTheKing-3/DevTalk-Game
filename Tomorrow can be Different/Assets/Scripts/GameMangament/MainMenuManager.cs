using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Function for when you click the "Start Game button"
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
