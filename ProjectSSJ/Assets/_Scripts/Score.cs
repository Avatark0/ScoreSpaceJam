using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private GameObject floor = default;
    
    [SerializeField] private Text text = default;

    private static int playerBugs = 0;
    private static float playerScore = 0;

    private int score = 0;

    void Update()
    {   
        playerScore += playerBugs*Time.deltaTime;
        score = FloorScore() + (int)playerScore;
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

    public static void PlayerBugs(int nFlys, int nCric, int nBees)
    {
        playerBugs = nFlys*nFlys + nCric + nBees;
    }

    public static void ResetStaticValues()
    {
        playerBugs = 0;
        playerScore = 0;
    }
}
