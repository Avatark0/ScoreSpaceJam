using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BugSoundEffects : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip pickedUp;
    [SerializeField] private AudioClip dying;
    [SerializeField] private AudioClip shooting;

    public void PickedUp()
    {
        audioSource.clip = pickedUp;
        audioSource.Play();
    }

    public void Dying()
    {
        audioSource.clip = dying;
        audioSource.Play();
    }

    public void Shooting()
    {
        audioSource.clip = shooting;
        audioSource.Play();
    }
}
