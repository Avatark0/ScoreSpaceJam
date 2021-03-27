using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BugSoundEffects : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource = default;

    [SerializeField] private AudioClip pickedUp = default;
    [SerializeField] private AudioClip dying = default;
    [SerializeField] private AudioClip shooting = default;

    public void PickedUpSound()
    {
        audioSource.clip = pickedUp;
        audioSource.Play();
    }

    public void DyingSound()
    {
        audioSource.clip = dying;
        audioSource.Play();
    }

    public void SkillSound()
    {
        audioSource.clip = shooting;
        audioSource.Play();
    }
}
