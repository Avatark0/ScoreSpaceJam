using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerButt : MonoBehaviour
{
    [SerializeField] private AudioSourcePrefab fireflyAudio;
    [SerializeField] private AudioSourcePrefab cricketAudio;
    [SerializeField] private AudioSourcePrefab beeAudio;

    public int fireflys;
    public int crickets;
    public int bees;

    private bool increase = true;

    public void AddBug(string bugType)
    {
        switch(bugType)
        {
            case "Firefly":
            {
                fireflys++;
                fireflyAudio.TrackVolumeControl(increase);
                break;
            }

            case "Cricket":
            {
                crickets++;
                cricketAudio.TrackVolumeControl(increase);
                break;
            }
                
            case "Bee":
            {
                bees++;
                beeAudio.TrackVolumeControl(increase);
                break;
            }
        }
    }

    public void RemoveBug(string bugType)
    {
        switch(bugType)
        {
            case "firefly":
            {
                fireflys--;
                fireflyAudio.TrackVolumeControl(!increase);
                break;
            }

            case "cricket":
            {
                crickets--;
                cricketAudio.TrackVolumeControl(!increase);
                break;
            }
                
            case "bee":
            {
                bees--;
                beeAudio.TrackVolumeControl(!increase);
                break;
            }
        }
    }
}
