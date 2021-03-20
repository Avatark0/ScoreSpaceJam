using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasControler : MonoBehaviour
{
    [SerializeField] private GameObject startMenu = default;
    [SerializeField] private GameObject gameMenu = default;
    [SerializeField] private GameObject endMenu = default;

    private bool paused;

    private void Start()
    {
        startMenu.SetActive(true);
        gameMenu.SetActive(false);
        endMenu.SetActive(false);
        Pause(); 
    }

    public void GameStart()
    {
        startMenu.SetActive(false);
        gameMenu.SetActive(true);
        endMenu.SetActive(false);
        Pause();
    }

    public void GameOver()
    {
        startMenu.SetActive(false);
        gameMenu.SetActive(false);
        endMenu.SetActive(true);
        Pause();
    }

    public void GameRestart()
    {
        string _name;
        _name = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(_name);
    }

    public void Pause()
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
        
        Debug.Log("Time.timeScale = "+Time.timeScale);
    }
}
