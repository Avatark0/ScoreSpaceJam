using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidDropParent : MonoBehaviour
{
    [SerializeField] private GameObject acidDropPrefab = default;
    [SerializeField] private GameObject floor = default;

    [SerializeField] private float limitLeft = default;
    [SerializeField] private float limitRight = default;

    [SerializeField] private float acidDropOffset = default;
    [SerializeField] private float roofOffset = default;
    [SerializeField, Range(0,1)] private float spawnChance = default;

    [SerializeField] private float nextDifRamp = 100;
    [SerializeField] private float difIncreaseTax = 5f;

    private float lastDropPos = 100;
    private float spawnChanceSum = 0;
    
    void Update()
    {
        if(floor.transform.position.y > acidDropOffset + lastDropPos)
        {
            spawnChanceSum+=Random.Range(0f,0.1f)*Time.deltaTime;
            if(spawnChanceSum>spawnChance)
            {
                GenerateAcidDrop();
                lastDropPos=floor.transform.position.y;
                spawnChanceSum = 0;
            }
        }

        if(floor.transform.position.y > nextDifRamp)
        {
            spawnChance = spawnChance * difIncreaseTax;
            nextDifRamp = nextDifRamp + 250;
        }
    }

    private void GenerateAcidDrop()
    {
        float posX = Random.Range(limitLeft, limitRight);
        float posY = floor.transform.position.y + roofOffset;
        Vector3 pos = new Vector3(posX, posY, 0);

        int i = Random.Range(0,3);
        Instantiate(acidDropPrefab, pos, Quaternion.identity, transform);
    }
}
