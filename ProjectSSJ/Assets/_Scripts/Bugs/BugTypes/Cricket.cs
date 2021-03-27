using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cricket : Bug
{
    public override void Effect()
    {
        //playerButt.GetComponent<PlayerButt>().DecreaseProximityThreshold();

        myState = State.skill;

        Death();
    }
}
