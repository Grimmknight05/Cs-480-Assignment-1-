using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController; //Ref to player controller
    [SerializeField] private int pointsNeededToWin = 25; //Score to win

    //public delegate void WinDelegate();
    //public event WinDelegate OnGameWon; //A player won

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController.OnScoreChanged += CheckWinCondition; //Add CheckWinCondition function to list of things called when OnScoreChanged is invoked
    }

    private void CheckWinCondition(int currentScore)
    {
        if (currentScore >= pointsNeededToWin)
        {
            gameWin();
        }
    }
    private void gameWin()
    {
        Debug.Log("Player wins!");
        //OnGameWon?.Invoke();//Invoke subscribers on won
        playerController.ShowWinScreen();
        Time.timeScale = 0f; // Pause the game
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
