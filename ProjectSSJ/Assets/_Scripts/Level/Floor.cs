using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] private float speed = default;

    [SerializeField] private float nextSpeedRamp = 100;
    [SerializeField] private float speedIncreaseTax = 1.1f;

    void Update()
    {
        Vector3 pos = transform.position;
        pos.y += speed*Time.deltaTime;
        transform.position=pos;    
    
        if(transform.position.y > nextSpeedRamp)
        {
            speed = speed * speedIncreaseTax;
            nextSpeedRamp = nextSpeedRamp + 50;
        }
    }
}
