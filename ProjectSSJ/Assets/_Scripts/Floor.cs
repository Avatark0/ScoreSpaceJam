using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] private float speed = default;

    void Update()
    {
        Vector3 pos = transform.position;
        pos.y += speed*Time.deltaTime;
        transform.position=pos;    
    }
}
