using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firefly : Bug
{
    public override void Effect()
    {
        Debug.Log("firefly effect!");
        //playerButt.GetComponent<PlayerButt>().DecreaseProximityThreshold();

        GetComponentInChildren<BugSoundEffects>().SkillSound();

        myState = State.skill;

        Death();
    }
}
