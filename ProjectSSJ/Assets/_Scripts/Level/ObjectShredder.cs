using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectShredder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // if(other.gameObject.tag == "Player")
        // {
        //     Debug.Log("ObjectShredder: player took damage");
        //     other.gameObject.GetComponent<Player>().TakeDamage();
        // }     
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("ObjectShredder: player took damage");
            other.gameObject.GetComponent<Player>().TakeDamage();
        }        
        else if(other.gameObject.tag != "Scenary" && other.gameObject.tag != "PlayerButt")
        {
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "PlayerButt" && other.gameObject.name != "Butt")
        {
            other.gameObject.GetComponent<Bug>().Death();
        }
    }
}
