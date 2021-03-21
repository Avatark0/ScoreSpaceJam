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
        Vector2 ini = ShooterAim.position;

        Vector2 end;
        end.x = transform.position.x;
        end.y = transform.position.y;
        
        Vector2 direction = (end - ini).normalized;
        
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

            }
            else if(other.gameObject.tag=="Bug")
            {

            }
            else if(other.gameObject.tag=="AcidDrop")
            {

            }

            AudioSource.PlayClipAtPoint(hitSound, transform.position);
            Destroy(gameObject);
        }
    }
}
