using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuSceneUImanagement : MonoBehaviour
{

    public Button menuPlayButton;
    public Button menuHTPButton;
    public Button menuExitButton;

    public GameObject mainMenuPanel;
    public GameObject HTPmenuPanel;

    public AudioClip uiClickSound;
    public AudioSource menuUIsoundSource;

    void Start()
    {
        Application.targetFrameRate = 60;

        mainMenuPanel.SetActive(true);
        HTPmenuPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onPlayGame()
    {
        menuUIsoundSource.clip = uiClickSound;
        menuUIsoundSource.Play();

        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void onHTP()
    {
        menuUIsoundSource.clip = uiClickSound;
        menuUIsoundSource.Play();

        mainMenuPanel.SetActive(false);
        HTPmenuPanel.SetActive(true);
    }

    public void onExit()
    {
        menuUIsoundSource.clip = uiClickSound;
        menuUIsoundSource.Play();

        Application.Quit();
    }

    public void onBack_htpPanel()
    {
        menuUIsoundSource.clip = uiClickSound;
        menuUIsoundSource.Play();

        mainMenuPanel.SetActive(true);
        HTPmenuPanel.SetActive(false);
    }
}
