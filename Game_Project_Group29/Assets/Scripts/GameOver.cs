using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Smith, Destiny
// 12/5/2023
// Controls the game over scene when the playeer dies. Retry button will retart the game, quit
// button will quit the game. Play Again will restart program.

public class GameOver : MonoBehaviour
{
    public PlayerController1 player;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    
    /// <summary>
    /// When Retry button is pressed, level 1 loads
    /// </summary>

    public void RetryGame()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// When Play Again button is pressed, main menu loads
    /// </summary>

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// When Quit button is pressed, application closes
    /// </summary>

    public void Quit()
    {
        Application.Quit();
    }

}