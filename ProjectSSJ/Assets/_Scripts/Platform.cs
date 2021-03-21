using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Sprite damaged = default;
    
    private int life = 10;

    public void Damage()
    {
        life--;
        if(life<0)
            Destroy(gameObject);
        else if(life<5)
            GetComponent<SpriteRenderer>().sprite=damaged;
    }
}
