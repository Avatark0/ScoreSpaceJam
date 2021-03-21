using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasControler : MonoBehaviour
{
    [SerializeField] private GameObject startMenu = default;
    [SerializeField] private GameObject gameMenu = default;
    [SerializeField] private GameObject endMenu = default;

    private static bool started;
    private static bool paused;

    private void Start()
    {
        startMenu.SetActive(true);
        gameMenu.SetActive(false);
        endMenu.SetActive(false);
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
    }

    public static void Pause()
    {
        if(started)
        {
            if(!paused)
            {
                Time.timeScale=0;
                paused=true;
            }
            else
            {
                Time.timeScale=1;
                paused=false;
            }
        }
    }
}
