using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private int life = 10;

    public void Damage()
    {
        life--;
        if(life<0)
            Destroy(gameObject);
    }
}
