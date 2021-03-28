using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : Bug
{
    public override void Effect()
    {
        playerButt.GetComponent<PlayerButt>().DecreaseProximityThreshold();

        myState = State.skill;

        gameObject.tag = "Bullet";
        Debug.Log("Bee effect");

        myRB.simulated=true;

        gameObject.AddComponent<Bullet>();
    }
}
