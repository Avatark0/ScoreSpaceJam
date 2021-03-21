using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioEffectControler : MonoBehaviour
{
    public AudioClip clip; //make sure you assign an actual clip here in the inspector

    void Start()
    {
        //AudioSource.PlayClipAtPoint(clip, new Vector3(5, 1, 2));
    }
}
