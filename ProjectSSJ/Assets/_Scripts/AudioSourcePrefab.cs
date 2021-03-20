using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioSourcePrefab : MonoBehaviour
{
    [SerializeField] private float increment = default;

    private AudioSource audioSource;
    
    private void OnEnable() 
    {
        audioSource=GetComponent<AudioSource>();
        ResetValues();  
    }

    private void Awake()
    {
        audioSource=GetComponent<AudioSource>();
        ResetValues();  
    }

    public void ResetValues()
    {
        if(gameObject.name == "Audio-Main")
            audioSource.volume = 1;
        else
            audioSource.volume = 0;
    }

    public void TrackVolumeControl(bool increase)
    {
        if(increase)
            audioSource.volume+=increment;
        else
            audioSource.volume-=increment;
    }
}
