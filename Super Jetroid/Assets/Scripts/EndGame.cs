using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    
    public int crystalsNeeded = 100;
    public int timeLimit = 20;
    private GameTimer gameTimer;
    private PlayerManager playerManager;
    // Start is called before the first frame update
    void Start()
    {
        gameTimer = GetComponent<GameTimer>();
        playerManager = GetComponent<PlayerManager>();
    }


    void Update()
    {
        // When player outlasts the time limit, 
        // move on to the win screen
        if (gameTimer.time >= timeLimit)
        {
            print("Failure. Time Over!");
            SceneManager.LoadScene("LoseScene");
        }

        if (playerManager.Lives < 0)
        {
            print("Game Over...");
            SceneManager.LoadScene("LoseScene");
        }

        if(gameTimer.crystalCount >= crystalsNeeded)
        {
            print("Mission Complete");
            SceneManager.LoadScene("WinScene");
        }
    }
}
