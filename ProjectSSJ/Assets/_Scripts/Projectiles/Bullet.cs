using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigBody = default;
    [SerializeField] private AudioClip hitSound = default;
    
    [SerializeField] private float baseForce = default;

    private void Start()
    {
        Vector2 direction = Vector2.up;
        
        float force = baseForce * BugAmount();
        
        Vector2 power = direction * force;
        
        rigBody.AddForce(power, ForceMode2D.Impulse);

        AudioSource.PlayClipAtPoint(hitSound, transform.position);
    }

    private float BugAmount()
    {
        return 1;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log(other.gameObject.name);
        if(other.gameObject.tag=="Player")
        {
            AudioSource.PlayClipAtPoint(hitSound, transform.position);
        }
        else if(other.gameObject.tag!="PlayerButt" && other.gameObject.tag!="Bullet")
        {
            if(other.gameObject.tag=="Platform")
            {
                other.gameObject.GetComponent<Platform>().Damage();
            }
            else if(other.gameObject.tag=="Bug")
            {
                other.gameObject.GetComponent<PowerUp>().Death();
            }
            else if(other.gameObject.tag=="AcidDrop")
            {
                other.gameObject.GetComponent<AcidDrop>().Death();
            }

            AudioSource.PlayClipAtPoint(hitSound, transform.position);
            Destroy(gameObject);
        }
    }
}
