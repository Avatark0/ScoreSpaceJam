using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSound : MonoBehaviour
{
    [SerializeField] private AudioSource myAS = default;
    private static AudioSource audioSource;

    private void Start()
    {
        audioSource = myAS;
    }

    public static void Play()
    {
        audioSource.Play();
    }


}
