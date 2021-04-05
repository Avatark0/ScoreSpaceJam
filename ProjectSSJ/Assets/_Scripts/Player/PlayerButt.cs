using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerButt : MonoBehaviour
{
    [Header("Bugs audio tracks")]
    [SerializeField] private AudioTrackControl fireflyAudio;
    [SerializeField] private AudioTrackControl cricketAudio;
    [SerializeField] private AudioTrackControl beeAudio;

    [Header("Attraction distance of caught bugs")]
    [SerializeField] private float proximityThreshold = 1;

    [Header("Current number of each bug caught")]
    public int fireflys;
    public int crickets;
    public int bees;

    [Header("Total number of each bug caught")]
    public int totalFireflys;
    public int totalCrickets;
    public int totalBees;

    [HideInInspector] public List<GameObject> bugs = new List<GameObject>();

    public void RestartAudioComponents()
    {
        foreach(GameObject audioTrack in GameObject.FindGameObjectsWithTag("AudioTrack"))
        {
            if(audioTrack.name == "AudioTrack-Firefly")
                if(fireflyAudio == null)
                    fireflyAudio = audioTrack.GetComponent<AudioTrackControl>();
            if(audioTrack.name == "AudioTrack-Cricket")
                if(cricketAudio == null)
                    cricketAudio = audioTrack.GetComponent<AudioTrackControl>();
            if(audioTrack.name == "AudioTrack-Bee")
                if(beeAudio == null)
                    beeAudio = audioTrack.GetComponent<AudioTrackControl>();
        } 
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
        proximityThreshold += 0.8f / proximityThreshold;
    }

    public void DecreaseProximityThreshold()
    {
        proximityThreshold -= 0.8f / proximityThreshold;
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
