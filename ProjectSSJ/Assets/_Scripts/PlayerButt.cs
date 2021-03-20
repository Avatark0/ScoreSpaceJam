using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerButt : MonoBehaviour
{
    public int fireflys;
    public int crickets;
    public int bees;

    public void AddBug(string bugType)
    {
        switch(bugType)
        {
            case "firefly":
                fireflys++;
                break;

            case "cricket":
                crickets++;
                break;
            
            case "bee":
                bees++;
                break;
        }
    }
}
