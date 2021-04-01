using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerButt : MonoBehaviour
{
    [Header("Bugs audio tracks")]
    [SerializeField] private AudioSourcePrefab fireflyAudio;
    [SerializeField] private AudioSourcePrefab cricketAudio;
    [SerializeField] private AudioSourcePrefab beeAudio;

    [Header("Attraction distance of caught bugs")]
    [SerializeField] private float proximityThreshold = 1;

    [HideInInspector] public List<GameObject> bugs = new List<GameObject>();

    [Header("Current number of each bug caught")]
    public int fireflys;
    public int crickets;
    public int bees;

    [Header("Total number of each bug caught")]
    public int totalFireflys;
    public int totalCrickets;
    public int totalBees;

    public void RestartAudioComponents()
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

        bool increase = true;

        switch(bug.name)
        {
            case "Firefly":
            {
                fireflys++;
                totalFireflys++;
                fireflyAudio.TrackVolumeControl(increase);
                Score.AddFly();
                break;
            }

            case "Cricket":
            {
                crickets++;
                totalCrickets++;
                cricketAudio.TrackVolumeControl(increase);
                Score.AddCri();
                break;
            }
                
            case "Bee":
            {
                bees++;
                totalBees++;
                beeAudio.TrackVolumeControl(increase);
                Score.AddBee();
                break;
            }
        }
    }

    public void LoseBug(GameObject bug)
    {
        bugs.Remove(bug);

        bool increase = true;

        switch(bug.name)
        {
            case "Firefly":
            {
                fireflys--;
                if(fireflys <= 28)
                    fireflyAudio.TrackVolumeControl(!increase);
                Score.SubFly();
                break;
            }

            case "Cricket":
            {
                crickets--;
                if(crickets <= 28)
                    cricketAudio.TrackVolumeControl(!increase);
                Score.SubCri();
                break;
            }
                
            case "Bee":
            {
                bees--;
                if(bees <= 28)
                    beeAudio.TrackVolumeControl(!increase);
                Score.SubBee();
                break;
            }
        }
    }

    public void IncreaseProximityThreshold()
    {
        proximityThreshold += 1 / proximityThreshold;
    }

    public void DecreaseProximityThreshold()
    {
        proximityThreshold -= 1 / proximityThreshold;
    }

    public float GetProximityThereshold()
    {
        return proximityThreshold;
    }

    public void UseBee()
    {
        if(bees>0)
        {
            int i = bugs.FindIndex(GameObject => GameObject.name == "Bee");
            bugs[i].GetComponent<Bug>().Effect();
            LoseBug(bugs[i]);
        }
    }

    public void UseCricket()
    {
        if(crickets>0)
        {
            int i = bugs.FindIndex(GameObject => GameObject.name == "Cricket");
            bugs[i].GetComponent<Bug>().Effect();
            LoseBug(bugs[i]);
        }
    }

    public bool UseFirefly()
    {
        if(fireflys>0)
        {
            int i = bugs.FindIndex(GameObject => GameObject.name == "Firefly");
            bugs[i].GetComponent<Bug>().Effect();
            LoseBug(bugs[i]);

            return true;
        }
        else
            return false;
    }
}
