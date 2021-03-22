using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidDrop : MonoBehaviour
{
    [SerializeField] private AudioClip splash = default;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        Death();    
    }

    public void Death()
    {
        AudioSource.PlayClipAtPoint(splash, transform.position);

        Destroy(gameObject);
    }
}
