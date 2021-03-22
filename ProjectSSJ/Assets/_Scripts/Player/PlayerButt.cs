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
    }

    public void LoseBug(GameObject bug)
    {
        bugs.Remove(bug);

        SubBug(bug.name);
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

    private void SubBug(string bugName)
    {
        bool increase = true;

        switch(bugName)
        {
            case "Firefly":
            {
                fireflys--;

                fireflyAudio.TrackVolumeControl(!increase);

                Score.SubFly();

                break;
            }

            case "Cricket":
            {
                crickets--;

                cricketAudio.TrackVolumeControl(!increase);

                Score.SubCri();

                break;
            }
                
            case "Bee":
            {
                bees--;

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

    public void BeeShoot()
    {
        if(bees>0)
        {
            int i = bugs.FindIndex(GameObject => GameObject.name == "Bee");
            bugs[i].GetComponent<PowerUp>().BugEffect();
            LoseBug(bugs[i]);
        }
    }

    public void CricketBoost()
    {
        if(crickets>0)
        {
            int i = bugs.FindIndex(GameObject => GameObject.name == "Cricket");
            bugs[i].GetComponent<PowerUp>().BugEffect();
            LoseBug(bugs[i]);
        }
    }

    public bool FireflyLife()
    {
        if(fireflys>0)
        {
            Debug.Log("PlayerButt: firefly saved yor life!");
            int i = bugs.FindIndex(GameObject => GameObject.name == "Firefly");
            bugs[i].GetComponent<PowerUp>().BugEffect();
            LoseBug(bugs[i]);

            return true;
        }
        else
            return false;
    }

    public void AglomerateBugs(GameObject bug)
    {
        //bug.GetComponent<PowerUp>().
    }
}
