using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerButt : MonoBehaviour
{
    [SerializeField] private AudioSourcePrefab fireflyAudio;
    [SerializeField] private AudioSourcePrefab cricketAudio;
    [SerializeField] private AudioSourcePrefab beeAudio;

    public List<PowerUp> bugs = new List<PowerUp>();

    public int fireflys;
    public int crickets;
    public int bees;

    private bool increase = true;

    public void AglomerateBugs()
    {
        //bugs.add()
    }

    public void RestartValues()
    {
        if(fireflyAudio==null)
            fireflyAudio=GameObject.Find("Audio-Firefly").GetComponent<AudioSourcePrefab>();
        if(cricketAudio==null)
            cricketAudio=GameObject.Find("Audio-Cricket").GetComponent<AudioSourcePrefab>();
        if(beeAudio==null)
            beeAudio=GameObject.Find("Audio-Bee").GetComponent<AudioSourcePrefab>();
    }

    public void AddBug(GameObject bug)
    {
        bugs.Add(bug.GetComponent<PowerUp>());
        switch(bug.name)
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

        Score.PlayerBugs(fireflys, crickets, bees);
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

        Score.PlayerBugs(fireflys, crickets, bees);
    }
}
