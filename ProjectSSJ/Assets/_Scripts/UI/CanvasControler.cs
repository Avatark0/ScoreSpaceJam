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

    private static bool gameStarted;
    private static bool gamePaused;

    private void Start()
    {
        startMenu.SetActive(true);
        gameMenu.SetActive(false);
        endMenu.SetActive(false);
        pauseMenu.SetActive(false);
        creditsMenu.SetActive(false);
        Time.timeScale = 0;
    }

    public void GameStart()
    {
        startMenu.SetActive(false);
        gameMenu.SetActive(true);
        endMenu.SetActive(false);
        Time.timeScale = 1;
        gameStarted = true;
    }

    public void GameOver()
    {
        startMenu.SetActive(false);
        gameMenu.SetActive(false);
        endMenu.SetActive(true);
        Time.timeScale = 0;
        gameStarted = false;
        GameOverSound.Play();
    }

    public void GameRestart()
    {
        ResetStaticValues();
        Score.ResetStaticValues();
        
        GlobalSpawner.ReInitLevel();

        string _name;
        _name = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(_name);
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
        if(gameStarted)
        {
            if(!gamePaused)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
                gamePaused = true;
            }
            else
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
                gamePaused = false;
            }
        }
    }

    public static bool IsPaused()
    {
        return gamePaused;
    }

    private void ResetStaticValues()
    {
        gameStarted = false;
        gamePaused = false;
    }
}
