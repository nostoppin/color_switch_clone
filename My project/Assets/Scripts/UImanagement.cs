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

    public AudioSource uiClickSoundSource;
    public AudioClip uiClickSound;

    void Start()
    {
        gameOverTextObject.text = "Game Over";
        gameOverMenuPanel.SetActive(false);
        pauseMenuPanel.SetActive(false);
        pauseButton.interactable = true;
    }

    void Update()
    {
        checkGameOver();
        scoreupdate();
        setHighScore();
    }

    public void onPauseButtonClick()
    {
        uiClickSoundSource.clip = uiClickSound;
        uiClickSoundSource.Play();

        Time.timeScale = 0f;

        pauseMenuPanel.SetActive(true);
        pauseButton.interactable = false;
    }

    public void onResumeButtonClick()
    {
        uiClickSoundSource.clip = uiClickSound;
        uiClickSoundSource.Play();

        Time.timeScale = 1f;

        pauseMenuPanel.SetActive(false);
        pauseButton.interactable = true;
    }

    public void onHomeButtonClick()
    {
        uiClickSoundSource.clip = uiClickSound;
        uiClickSoundSource.Play();
        
        SceneManager.LoadScene(0);
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
        uiClickSoundSource.clip = uiClickSound;
        uiClickSoundSource.Play();

        playerObjectref.GetComponent<playerMovement>().gameOverFlag = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void setHighScore()
    {
        int currentPlayerScore = playerObjectref.GetComponent<playerMovement>().setCurrentScore();

        if (currentPlayerScore > PlayerPrefs.GetInt("HighScore"))
        {
            playerScoreOnGameOver.text = currentPlayerScore.ToString();
            gameOverTextObject.text = "New Highscore";

            PlayerPrefs.SetInt("highscore", currentPlayerScore);
            playerHighScore.text = PlayerPrefs.GetInt("highscore").ToString();
        }
        else
        {
            gameOverTextObject.text = "Game Over";
            playerScoreOnGameOver.text = currentPlayerScore.ToString();

            playerHighScore.text = PlayerPrefs.GetInt("highscore").ToString();
        }
    }
}
