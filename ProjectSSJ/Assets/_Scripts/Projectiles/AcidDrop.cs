using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidDrop : MonoBehaviour
{
    [SerializeField] private AudioClip splash = default;
    [SerializeField] private float speed = default;

    private void Update()
    {
        Vector3 pos = transform.position;
        pos.y -= (speed + ScrollController.GetScrollSpeed()) * Time.deltaTime;
        transform.position = pos;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().HitByDrop();
        }

        Death();    
    }

    public void Death()
    {
        AudioSource.PlayClipAtPoint(splash, transform.position);

        Destroy(gameObject);
    }
}
