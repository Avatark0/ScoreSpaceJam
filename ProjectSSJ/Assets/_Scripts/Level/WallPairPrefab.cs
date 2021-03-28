using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPairPrefab : MonoBehaviour
{
    void Update()
    {
        Vector3 pos = transform.position;
        pos.y -= ScrollController.scrollSpeed * Time.deltaTime;
        transform.position = pos;       
    }
}
