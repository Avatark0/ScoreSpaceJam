using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private GameObject floor = default;
    [SerializeField] private GameObject player = default;

    [SerializeField] private Text text = default;

    private int score = 0;

    void Update()
    {   
        score = FloorScore() + PlayerScore();
        text.text = score.ToString();
    }

    private int FloorScore()
    {
        int floorScore = (int)floor.transform.position.y;
        if(floorScore < 0)
            floorScore = 0;
        floorScore = floorScore*10;

        return floorScore;
    }

    private int PlayerScore()
    {
        int playerScore = (int)player.transform.position.y;
        return 0;
    }
}
