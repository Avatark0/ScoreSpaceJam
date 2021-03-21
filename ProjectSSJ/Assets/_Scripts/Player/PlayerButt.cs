using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerButt : MonoBehaviour
{
    [SerializeField] private AudioSourcePrefab fireflyAudio;
    [SerializeField] private AudioSourcePrefab cricketAudio;
    [SerializeField] private AudioSourcePrefab beeAudio;

    [SerializeField] private float proximityThreshold = 1;

    public List<GameObject> bugs = new List<GameObject>();

    public int fireflys;
    public int crickets;
    public int bees;

    public int totalFireflys;
    public int totalCrickets;
    public int totalBees;

    public void RestartValues()
    {
        if(fireflyAudio==null)
            fireflyAudio=GameObject.Find("Audio-Firefly").GetComponent<AudioSourcePrefab>();
        if(cricketAudio==null)
            cricketAudio=GameObject.Find("Audio-Cricket").GetComponent<AudioSourcePrefab>();
        if(beeAudio==null)
            beeAudio=GameObject.Find("Audio-Bee").GetComponent<AudioSourcePrefab>();
    }

    public void CatchBug(GameObject bug)
    {
        bugs.Add(bug);

        AddBug(bug.name);

        Score.PlayerBugs(fireflys, crickets, bees);
    }

    public void LoseBug(GameObject bug)
    {
        bugs.Remove(bug);

        SubBug(bug.name);

        Score.PlayerBugs(fireflys, crickets, bees);
    }

    private void AddBug(string bugName)
    {
        bool increase = true;

        switch(bugName)
        {
            case "Firefly":
            {
                fireflys++;
                totalFireflys++;
                fireflyAudio.TrackVolumeControl(increase);
                break;
            }

            case "Cricket":
            {
                crickets++;
                totalCrickets++;
                cricketAudio.TrackVolumeControl(increase);
                break;
            }
                
            case "Bee":
            {
                bees++;
                totalBees++;
                beeAudio.TrackVolumeControl(increase);
                break;
            }
        }
    }

    private void SubBug(string bugName)
    {
        bool increase = true;

        switch(bugName)
        {
            case "Firefly":
            {
                fireflys--;
                fireflyAudio.TrackVolumeControl(!increase);
                break;
            }

            case "Cricket":
            {
                crickets--;
                cricketAudio.TrackVolumeControl(!increase);
                break;
            }
                
            case "Bee":
            {
                bees--;
                beeAudio.TrackVolumeControl(!increase);
                break;
            }
        }
    }

    public void AglomerateBugs(GameObject bug)
    {
        //bug.GetComponent<PowerUp>().
    }

    public void IncreaseProximityThreshold()
    {
        proximityThreshold += (proximityThreshold + 1) / proximityThreshold;
    }

    public float GetProximityThereshold()
    {
        return proximityThreshold;
    }
}
