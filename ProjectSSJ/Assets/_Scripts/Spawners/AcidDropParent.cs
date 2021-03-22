using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidDropParent : MonoBehaviour
{
    [SerializeField] private GameObject acidDropPrefab = default;
    [SerializeField] private GameObject floor = default;

    [SerializeField] private float limitLeft = default;
    [SerializeField] private float limitRight = default;

    //[SerializeField] private float acidDropOffset = default;
    [SerializeField] private float roofOffset = default;
    //[SerializeField, Range(0,1)] private float spawnChance = default;

    //[SerializeField] private float nextDifRamp = 100;
    //[SerializeField] private float difIncreaseTax = 5f;

    //private float lastDropPos = 100;
    //private float spawnChanceSum = 0;
    
    void Update()
    {
        if(GlobalSpawner.IsTimeForDrop()) {
            GenerateAcidDrop();
        }
    }

    private void GenerateAcidDrop()
    {
        float[] rands = GlobalSpawner.NextDrop();
        float posX = (limitRight-limitLeft)*rands[0] + limitLeft;
        float posY = floor.transform.position.y + roofOffset;
        Vector3 pos = new Vector3(posX, posY, 0);

        int i = (int)Mathf.Floor(rands[1] * 3);
        Instantiate(acidDropPrefab, pos, Quaternion.identity, transform);
    }
}
