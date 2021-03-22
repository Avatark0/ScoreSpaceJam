using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //[SerializeField] private AudioClip hitSound = default;
    
    private float force = 8f;

    private void Start()
    {
        GameObject bulletParent;
        bulletParent = GameObject.FindWithTag("BulletParent");
        transform.SetParent(bulletParent.transform);

        Vector2 direction = Vector2.up;
        Vector2 power = direction * force;
        
        Rigidbody2D rigBody;
        rigBody =  gameObject.AddComponent<Rigidbody2D>();
        rigBody.mass = 0.1f;
        rigBody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

        rigBody.AddForce(power, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log(other.gameObject.name);
        if(other.gameObject.tag!="Player")
        {
           if(other.gameObject.tag!="PlayerButt" && other.gameObject.tag!="Bullet")
            {
                if(other.gameObject.tag=="Platform")
                {
                    other.gameObject.GetComponent<Platform>().Damage();
                }
                else if(other.gameObject.tag=="Bug")
                {
                    other.gameObject.GetComponent<PowerUp>().AttachToPlayerButt();
                }
                else if(other.gameObject.tag=="AcidDrop")
                {
                    other.gameObject.GetComponent<AcidDrop>().Death();
                }

                //AudioSource.PlayClipAtPoint(hitSound, transform.position);
                Destroy(gameObject);
            }
        }
    }
}
