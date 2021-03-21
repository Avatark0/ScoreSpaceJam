using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterAim : MonoBehaviour
{
    public static Vector2 position;

    private void Update() {
        position = transform.position;
    }
}
