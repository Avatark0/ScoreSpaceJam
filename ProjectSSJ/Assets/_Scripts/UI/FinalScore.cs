using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    [SerializeField] private Text finalScore = default;
    [SerializeField] private Text score = default;

    private void OnEnable()
    {
        finalScore.text=score.text; 
    }
}
