using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugShoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet = default;
    
    [SerializeField] private GameObject bulletParent;

    private void Start() 
    {
        bulletParent=GameObject.FindWithTag("BulletParent");
    }

    private void Update()
    {
        if(tag == "PlayerButt")
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(bullet, transform.position, Quaternion.identity, bulletParent.transform);
            }
    }
}
