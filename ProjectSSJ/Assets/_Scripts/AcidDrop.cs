using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidDrop : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Acid splashed on "+other);
        Destroy(gameObject);    
    }
}
