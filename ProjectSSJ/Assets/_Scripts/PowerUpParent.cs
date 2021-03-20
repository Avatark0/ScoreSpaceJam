using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpParent : MonoBehaviour
{
    [SerializeField] private GameObject[] powerUpPrefabs = default;
    [SerializeField] private GameObject floor = default;
    [SerializeField] private GameObject playerButt = default;

    [SerializeField] private float limitLeft = default;
    [SerializeField] private float limitRight = default;

    [SerializeField] private float powerUpOffset = default;
    [SerializeField] private float roofOffset = default;
    [SerializeField, Range(0.1f,0)] private float spawnChance = default;

    [SerializeField] private float nextSpawnRamp = 100;
    [SerializeField, Range(1,0)] private float spawnIncreaseTax = 0.65f;

    private float lastPowerUpPos = 0;
    private float spawnChanceSum = 0;
    
    void Update()
    {
        if(floor.transform.position.y - lastPowerUpPos > powerUpOffset)
        {
            spawnChanceSum+=Random.Range(0f,0.1f)*Time.deltaTime;
            if(spawnChanceSum>spawnChance)
            {
                GeneratePowerUp();
                lastPowerUpPos=floor.transform.position.y;
                spawnChanceSum = 0;
            }
        }

        if(floor.transform.position.y > nextSpawnRamp)
        {
            spawnChance = spawnChance*spawnIncreaseTax;
            nextSpawnRamp = nextSpawnRamp + 200;
        }
    }

    private void GeneratePowerUp()
    {
        float posX = Random.Range(limitLeft, limitRight);
        float posY = floor.transform.position.y + roofOffset;
        Vector3 pos = new Vector3(posX, posY, 0);

        int i = Random.Range(0,3);
        
        GameObject powerUp = Instantiate(powerUpPrefabs[i], pos, Quaternion.identity, transform);
        powerUp.GetComponent<PowerUp>().SetPlayerObj(playerButt);

        switch(i)
        {
            case 0:
                powerUp.name = "Firefly";
                break;
            case 1:
                powerUp.name = "Cricket";
                break;
            case 2:
                powerUp.name = "Bee";
                break;
        }
    }
}
