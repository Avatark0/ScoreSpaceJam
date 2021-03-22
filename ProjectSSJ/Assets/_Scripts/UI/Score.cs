using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private GameObject floor = default;
    
    [SerializeField] private Text scoreText = default;
    [SerializeField] private Text fireflyText = default;
    [SerializeField] private Text cricketText = default;
    [SerializeField] private Text beeText = default;

    private static int flyValue = 50;
    private static int criValue = 10;
    private static int beeValue = 10;

    private static int fireflys = 0;
    private static int crickets = 0;
    private static int bees = 0;
    private static int bugs = 0;

    private static int totalFly = 0;
    private static int totalCri = 0;
    private static int totalBee = 0;
    private static int totalBug = 0;

    private static int score = 0;

    void Update()
    {   
        scoreText.text = score.ToString();
        fireflyText.text = fireflys.ToString();
        cricketText.text = crickets.ToString();
        beeText.text = bees.ToString();
    }

    public static void ResetStaticValues()
    {
        fireflys = 0;
        crickets = 0;
        bees = 0;
        bugs = 0;

        totalFly = 0;
        totalCri = 0;
        totalBee = 0;
        totalBug = 0;
        
        score = 0;
    }

    public static void AddFly()
    {
        fireflys++;
        totalFly++;

        bugs++;
        totalBug++;
        
        score+=flyValue;
    }

    public static void AddCri()
    {
        crickets++;
        totalCri++;

        bugs++;
        totalBug++;

        score+=criValue;
    }

    public static void AddBee()
    {
        bees++;
        totalBee++;

        bugs++;
        totalBug++;

        score+=beeValue;
    }

    public static void SubFly()
    {
        fireflys--;
        bugs--;
    }

    public static void SubCri()
    {
        crickets--;
        bugs--;
    }

    public static void SubBee()
    {
        bees--;
        bugs--;
    }

    public static int GetTotalFly()
    {
        return totalFly;
    }

    public static int GetTotalCri()
    {
        return totalCri;
    }

    public static int GetTotalBee()
    {
        return totalBee;
    }

    public static int GetFinalScore()
    {
        return score;
    }
}
