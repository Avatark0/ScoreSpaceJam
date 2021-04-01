using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 12f;
    
    private void Start()
    {
        GameObject bulletParent;
        bulletParent = GameObject.FindWithTag("BulletParent");
        transform.SetParent(bulletParent.transform);
        GetComponent<CapsuleCollider2D>().isTrigger = true;
    }

    private void Update()
    {
        Vector2 pos = transform.position;
        pos.y += speed * Time.deltaTime;
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        string tag = other.gameObject.tag;
        if(tag != "Player" && tag != "PlayerButt" && tag != "Bullet")
        {
            if(other.gameObject.tag == "Platform")
            {
                other.gameObject.GetComponent<Platform>().Damage();
                other.gameObject.GetComponent<Platform>().Damage();
                other.gameObject.GetComponent<Platform>().Damage();

                GetComponent<Bug>().Death();
            }
            else if(other.gameObject.tag == "Bug")
            {
                other.gameObject.GetComponent<Bug>().AttachToPlayerButt();
            }
            else if(other.gameObject.tag == "AcidDrop")
            {
                other.gameObject.GetComponent<AcidDrop>().Death();
            }
        }
    }
}
