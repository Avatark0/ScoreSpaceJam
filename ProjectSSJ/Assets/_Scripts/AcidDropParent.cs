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

    private float lastAcidDropPos = 0;
    private float spawnChanceSum = 0;
    
    void Update()
    {
        if(floor.transform.position.y - lastAcidDropPos > acidDropOffset)
        {
            spawnChanceSum+=Random.Range(0f,0.1f)*Time.deltaTime;
            if(spawnChanceSum>spawnChance)
            {
                GenerateAcidDrop();
                lastAcidDropPos=floor.transform.position.y;
                spawnChanceSum = 0;
            }
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
