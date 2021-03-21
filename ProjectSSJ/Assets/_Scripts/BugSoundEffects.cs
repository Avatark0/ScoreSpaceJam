using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSoundEffects : MonoBehaviour
{
    [SerializeField] private AudioClip pickedUp;
    [SerializeField] private AudioClip dying;
    [SerializeField] private AudioClip shooting;

    public void PickedUp()
    {
        AudioSource.PlayClipAtPoint(pickedUp, transform.position);
    }

    public void Dying()
    {
        AudioSource.PlayClipAtPoint(dying, transform.position);
    }

    public void Shooting()
    {
        AudioSource.PlayClipAtPoint(shooting, transform.position);
    }
}
