using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallParent : MonoBehaviour
{
    [Header("GameObject prefab")]
    [SerializeField] private GameObject wallPair = default;
    [SerializeField] private GameObject floor = default;

    [SerializeField] private float verticalWallOffset = default;

    [SerializeField] private GameObject generatedWalls_older;
    [SerializeField] private GameObject generatedWalls_newer;

    private void Update()
    {
        if(floor.transform.position.y - generatedWalls_older.transform.position.y > verticalWallOffset)
        {
            GenerateWalls();
        }
    }

    private void GenerateWalls()
    {
        float posY = floor.transform.position.y + verticalWallOffset;
        Vector3 pos = new Vector3(0, posY, 0);

        GameObject generatedWalls_toDestroy = generatedWalls_older;

        generatedWalls_older = generatedWalls_newer;
        generatedWalls_newer = Instantiate(wallPair, pos, Quaternion.identity, transform);

        Destroy(generatedWalls_toDestroy);
    }
}
