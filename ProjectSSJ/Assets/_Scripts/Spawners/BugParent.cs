using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugParent : MonoBehaviour
{
    [SerializeField] private GameObject[] bugPrefabs = default;
    [Header("Fetch in Hierarchy")]
    [SerializeField] private GameObject floor = default;
    [SerializeField] private GameObject playerButt = default;
    [Header("Controls")]
    [SerializeField] private float limitLeft = default;
    [SerializeField] private float limitRight = default;
    [SerializeField] private float roofOffset = default;
    [Header("Spawn rates")]
    [SerializeField, Range(0.1f,100f)] private float portion_firefly = 10f;
    [SerializeField, Range(0.1f,100f)] private float portion_cricket = 30f;
    [SerializeField, Range(0.1f,100f)] private float portion_bee = 100f;

    void Update()
    {
        if (GlobalSpawner.IsTimeForBug()) 
        {
            GenerateBug();
        }
    }

    private void GenerateBug()
    {
        float[] rands = GlobalSpawner.NextBug();
        float posX = (limitRight-limitLeft)*rands[0] + limitLeft;
        float posY = floor.transform.position.y + roofOffset;
        Vector3 pos = new Vector3(posX, posY, 0);

        float scaled = rands[1] * (portion_firefly + portion_cricket + portion_bee);
        //Debug.Log(rands[1] + " => " + scaled);
        int i = 0; // firefly
        if (scaled > portion_firefly) {
            i = 1; // cricket
        }
        if (scaled > portion_firefly + portion_cricket) {
            i = 2; // bee
        }

        GameObject bug = Instantiate(bugPrefabs[i], pos, Quaternion.identity, transform);
        bug.GetComponent<Bug>().SetPlayerObj(playerButt);

        switch(i)
        {
            case 0:
                bug.name = "Firefly";
                break;
            case 1:
                bug.name = "Cricket";
                break;
            case 2:
                bug.name = "Bee";
                break;
        }
    }
}
