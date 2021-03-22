using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasControler : MonoBehaviour
{
    [SerializeField] private GameObject startMenu = default;
    [SerializeField] private GameObject gameMenu = default;
    [SerializeField] private GameObject endMenu = default;
    [SerializeField] private GameObject pauseMenu = default;
    [SerializeField] private GameObject creditsMenu = default;

    private static bool started;
    private static bool paused;

    private void Start()
    {
        startMenu.SetActive(true);
        gameMenu.SetActive(false);
        endMenu.SetActive(false);
        pauseMenu.SetActive(false);
        creditsMenu.SetActive(false);
        Time.timeScale=0;
    }

    public void GameStart()
    {
        startMenu.SetActive(false);
        gameMenu.SetActive(true);
        endMenu.SetActive(false);
        Time.timeScale=1;
        started=true;
    }

    public void GameOver()
    {
        startMenu.SetActive(false);
        gameMenu.SetActive(false);
        endMenu.SetActive(true);
        Time.timeScale=0;
        started=false;
    }

    public void GameRestart()
    {
        string _name;
        _name = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(_name);
        GlobalSpawner.ReInitLevel();
        Score.ResetStaticValues();
    }

    public void Credits()
    {
        if(!creditsMenu.activeSelf)
            creditsMenu.SetActive(true);
        else
            creditsMenu.SetActive(false);
    }

    public void Pause()
    {
        if(started)
        {
            if(!paused)
            {
                pauseMenu.SetActive(true);
                Time.timeScale=0;
                paused=true;
            }
            else
            {
                pauseMenu.SetActive(false);
                Time.timeScale=1;
                paused=false;
            }
        }
    }
}
