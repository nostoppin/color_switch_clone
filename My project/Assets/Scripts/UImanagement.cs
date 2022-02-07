using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UImanagement : MonoBehaviour
{
    public Button pauseButton;
    public Button resumeButton;
    public Button homeButton;

    public Text playerScore;

    public GameObject pauseMenuPanel;

    public GameObject playerObjectref;

    // Start is called before the first frame update
    void Start()
    {

        pauseMenuPanel.SetActive(false);
        pauseButton.interactable = true;
    }

    // Update is called once per frame
    void Update()
    {
        scoreupdate();
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

    }

    public void scoreupdate()
    {
        float scoreVariable = playerObjectref.GetComponent<playerMovement>().setCurrentScore();

        playerScore.text = scoreVariable.ToString();
    }
}
