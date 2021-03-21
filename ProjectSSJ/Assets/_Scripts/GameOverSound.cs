using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSound : MonoBehaviour
{
    [SerializeField] private AudioClip gameOver = default;

    private void OnDestroy() 
    {
        AudioSource.PlayClipAtPoint(gameOver, transform.position);
    }
}
