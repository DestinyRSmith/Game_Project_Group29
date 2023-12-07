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
    public void RetryGame()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}