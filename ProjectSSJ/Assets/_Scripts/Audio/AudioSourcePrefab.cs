using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioSourcePrefab : MonoBehaviour
{
    private AudioSource audioSource;
    
    private void OnEnable() 
    {
        ResetValues();  
    }

    public void ResetValues()
    {
        if(audioSource==null)
            audioSource=GetComponent<AudioSource>();

        if(gameObject.name == "Audio-Main")
            audioSource.volume = 0.8f;
        else
            audioSource.volume = 0;
    }

    public void TrackVolumeControl(bool increase)
    {
        int increment;

        if(audioSource==null)
            audioSource=GetComponent<AudioSource>();
        
        if(increase)
        {
            if(audioSource.volume < 0.25f)
            {
                increment = 25;
                audioSource.volume += increment/100f;
            }
            else if(audioSource.volume < 0.81f)
            {
                increment = 8;
                audioSource.volume += increment/100f;
            }
            else if(audioSource.volume < 1)
            {
                increment = 1;
                audioSource.volume += increment/100f;
            }
        }
        else
        {
            if(audioSource.volume > 0.81f)
            {
                increment = 1;
                audioSource.volume -= increment/100f;
            }
            else if(audioSource.volume > 0.25f)
            {
                increment = 8;
                audioSource.volume -= increment/100f;
            }
            else if(audioSource.volume > 0)
            {
                increment = 25;
                audioSource.volume -= increment/100f;
            }            
        }
    }
}
