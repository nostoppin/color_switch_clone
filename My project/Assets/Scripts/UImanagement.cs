using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UImanagement : MonoBehaviour
{
    public Button pauseButton;
    public Button resumeButton;
    public Button homeButton;

    public Text playerScore;
    public Text playerScoreOnGameOver;
    public Text playerHighScore;
    public Text gameOverTextObject;

    public GameObject pauseMenuPanel;
    public GameObject gameOverMenuPanel;

    public GameObject playerObjectref;


    // Start is called before the first frame update
    void Start()
    {
        gameOverTextObject.text = "Game Over";
        gameOverMenuPanel.SetActive(false);
        pauseMenuPanel.SetActive(false);
        pauseButton.interactable = true;
    }

    // Update is called once per frame
    void Update()
    {
        checkGameOver();
        scoreupdate();
        setHighScore();
    }

    public void onPauseButtonClick()
    {
        Time.timeScale = 0f;

        pauseMenuPanel.SetActive(true);
        pauseButton.interactable = false;
    }

    public void onResumeButtonClick()
    {
        Time.timeScale = 1f;

        pauseMenuPanel.SetActive(false);
        pauseButton.interactable = true;
    }

    public void onHomeButtonClick()
    {
        //return to home screen
    }

    public void scoreupdate()
    {
        float scoreVariable = playerObjectref.GetComponent<playerMovement>().setCurrentScore();

        playerScore.text = scoreVariable.ToString();
    }

    private void checkGameOver()
    {
        if(playerObjectref.GetComponent<playerMovement>().gameOverFlag == true)
        {
            Time.timeScale = 0f;
            gameOverMenuPanel.SetActive(true);
        }
    }

    public void onRetryGame()
    {
        //get a flag from player's collision script
        //if(playerObjectref.GetComponent<playerMovement>().gameOverFlag == true)
        {
            playerObjectref.GetComponent<playerMovement>().gameOverFlag = false;
            //reset game using scene management
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
        }
    }

    private void setHighScore()
    {
        float currentPlayerScore = playerObjectref.GetComponent<playerMovement>().setCurrentScore();
        //print(g_current_score);
        if (currentPlayerScore > PlayerPrefs.GetInt("HighScore"))
        {
            playerScoreOnGameOver.text = currentPlayerScore.ToString();
            gameOverTextObject.text = "New Highscore";
        }
        else
        {
            gameOverTextObject.text = "Game Over";
            playerScoreOnGameOver.text = currentPlayerScore.ToString();
        }
    }
}
