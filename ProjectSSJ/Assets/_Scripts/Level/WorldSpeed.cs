using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpeed : MonoBehaviour
{
    [Header("Screen Scroll Stats")]
    [SerializeField] private float worldSpeed = default;
    [SerializeField] private float timestep_to_increase_difficuty = default;

    private float timer;

    private void Start()
    {
        timer = Time.time;
    }

    private void Update() 
    {
        ScrollController.SetScrollSpeed(worldSpeed);
        
        if( Time.time - timer > timestep_to_increase_difficuty)
        {
            worldSpeed += 1;
            timer = Time.time;
        }

        if(worldSpeed > 25)
            timestep_to_increase_difficuty = 5;
        else if(worldSpeed > 10)
            timestep_to_increase_difficuty = 10;
    }
}
