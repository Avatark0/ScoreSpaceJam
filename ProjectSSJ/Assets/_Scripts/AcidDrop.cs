using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidDrop : MonoBehaviour
{
    [SerializeField] private AudioClip splash = default;
    [SerializeField] private Sprite spriteType2 = default;

    private void Start()
    {
        if(Random.Range(0,2) > 0)
        {
            //removed second acid shoot
            //GetComponentInChildren<SpriteRenderer>().sprite = spriteType2;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Acid splashed on "+other);
        Death();    
    }

    public void Death()
    {
        AudioSource.PlayClipAtPoint(splash, transform.position);

        Destroy(gameObject);
    }
}
