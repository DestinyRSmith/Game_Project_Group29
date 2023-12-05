using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Smith, Destiny
// 11/6/2023
// Manages the text and UI in the game

public class UIManager : MonoBehaviour
{
    public TMP_Text totalLivesText;
    public TMP_Text totalScoreText;
    public PlayerController1 playerController;

    // Update is called once per frame
    void Update()
    {
        totalLivesText.text = "Lives: " + playerController.lives;
        totalLivesText.text = "Score: " + playerController.score;
    }
}
