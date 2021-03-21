using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    [SerializeField] private Text fireflyText = default;
    [SerializeField] private Text cricketText = default;
    [SerializeField] private Text beeText = default;
    [SerializeField] private Text finalScoreText = default;

    private int totalFly = 0;
    private int totalCri = 0;
    private int totalBee = 0;

    private int finalScore = 0;

    private void OnEnable()
    {
        Debug.Log("FinalScore Enabled");

        totalFly = Score.GetTotalFly();
        totalCri = Score.GetTotalCri();
        totalBee = Score.GetTotalBee();

        finalScore = Score.GetFinalScore();

        fireflyText.text = totalFly.ToString();
        cricketText.text = totalCri.ToString();
        beeText.text = totalBee.ToString();

        finalScoreText.text = finalScore.ToString();
    }
}
