using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private int life = 3;
    [SerializeField] private Sprite[] damageStates = default;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            if(other.gameObject.GetComponent<Player>().shieldDamageFrames)
            {
                Damage();
            }
        }    
    }

    public void Damage()
    {
        life--;
        if(life==2)
            GetComponent<SpriteRenderer>().sprite=damageStates[2];
        else if(life==1)
            GetComponent<SpriteRenderer>().sprite=damageStates[1];
        else if(life==0)
        {
            GetComponent<SpriteRenderer>().sprite=damageStates[0];
            Destroy(gameObject);
        }
    }
}
