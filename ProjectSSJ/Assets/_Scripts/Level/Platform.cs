using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private int life = 3;
    [SerializeField] private Sprite[] damageStates = default;

    private void Update()
    {
        Vector2 pos = transform.position;
        pos.y -= ScrollController.GetScrollSpeed() * Time.deltaTime;
        transform.position = pos;
    }

    public void Damage()
    {
        life--;
        if(life==2)
            GetComponentInChildren<SpriteRenderer>().sprite=damageStates[2];
        else if(life==1)
            GetComponentInChildren<SpriteRenderer>().sprite=damageStates[1];
        else if(life==0)
        {
            GetComponentInChildren<SpriteRenderer>().sprite=damageStates[0];
            
            for(int i = 0; i < transform.childCount; i++)
            {
                if(transform.GetChild(i).gameObject.tag == "Bug")
                    transform.GetChild(i).GetComponent<Bug>().AttachToPlayerButt();
            }
            
            Destroy(gameObject);
        }
    }
}