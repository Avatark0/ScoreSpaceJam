using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugShoot : MonoBehaviour
{
    
    [SerializeField] private GameObject bulletParent;

    private void Awake() 
    {
        bulletParent=GameObject.FindWithTag("BulletParent");
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(transform.parent == bulletParent.transform)
        {
            if(gameObject.name != "Bee")
                GetComponent<PowerUp>().Death();
        }
    }
}
