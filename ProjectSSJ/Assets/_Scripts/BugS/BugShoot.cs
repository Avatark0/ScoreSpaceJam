using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugShoot : MonoBehaviour
{
    
    [SerializeField] private GameObject bulletParent;

    private void Awake() 
    {
        bulletParent=GameObject.FindWithTag("BulletParent");
        Debug.Log("BugShoot: bulletParent = "+bulletParent.name);
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(transform.parent == bulletParent.transform)
        {
            Effect(other);
        }
    }

    private void FireflyEffect(Collision2D col)
    {
        Debug.Log("firefly effect at: "+col.gameObject.name);
    }

    private void CricketEffect(Collision2D col)
    {
        Debug.Log("cricket effect at: "+col.gameObject.name);
    }

    private void BeeEffect(Collision2D col)
    {
        Debug.Log("bee effect at: "+col.gameObject.name);
    }

    private void Effect(Collision2D col)
    {
        switch(gameObject.name)
        {
            case "Firefly":
            {
                FireflyEffect(col);
                break;
            }
            case "Cricket":
            {
                CricketEffect(col);
                break;
            }
            case "Bee":
            {
                BeeEffect(col);
                break;
            }
        }
    }

    private void ButterflyEffect()
    {
        //What if we alweys started in seed X; but usig this effect woul change the seed to be X++
        //Also, should the seed ++ after each round? We could loop beetwen the first 16 seeds or something
    }
}
