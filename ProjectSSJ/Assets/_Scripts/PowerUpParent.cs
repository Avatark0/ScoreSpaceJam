using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpParent : MonoBehaviour
{
    [SerializeField] private GameObject powerUp = default;
    [SerializeField] private GameObject floor = default;

    [SerializeField] private float limitLeft = default;
    [SerializeField] private float limitRight = default;

    [SerializeField] private float verticalPowerUpOffset = default;
    [SerializeField] private float verticalRoofOffset = default;
    [SerializeField, Range(0,1)] private float spawnChance = default;

    private float lastPowerUpPos = 0;
    private float spawnChanceSum = 0;
    
    void Update()
    {
        if(floor.transform.position.y - lastPowerUpPos > verticalPowerUpOffset)
        {
            spawnChanceSum+=Random.Range(0f,0.1f)*Time.deltaTime;
            if(spawnChanceSum>spawnChance)
            {
                GeneratePowerUp();
                lastPowerUpPos=floor.transform.position.y;
                spawnChanceSum = 0;
            }
        }
    }

    private void GeneratePowerUp()
    {
        float posX = Random.Range(limitLeft, limitRight);
        float posY = floor.transform.position.y + verticalRoofOffset;
        Vector3 pos = new Vector3(posX, posY, 0);

        Instantiate(powerUp, pos, Quaternion.identity, transform);
    }
}
