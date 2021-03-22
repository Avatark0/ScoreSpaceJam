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
        if (GlobalSpawner.IsTimeForBug()) {
            GeneratePowerUp();
        }
    }

    private void GeneratePowerUp()
    {
        float[] rands = GlobalSpawner.NextBug();
        float posX = (limitRight-limitLeft)*rands[0] + limitLeft;
        float posY = floor.transform.position.y + roofOffset;
        Vector3 pos = new Vector3(posX, posY, 0);

        int i = (int) Mathf.Floor(rands[1]*3);
        
        GameObject powerUp = Instantiate(powerUpPrefabs[i], pos, Quaternion.identity, transform);
        powerUp.GetComponent<PowerUp>().SetPlayerObj(playerButt);
        powerUp.GetComponent<PowerUp>().SetPowerUpParentObj(gameObject);

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
