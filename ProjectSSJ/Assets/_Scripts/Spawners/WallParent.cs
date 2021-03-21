using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallParent : MonoBehaviour
{
    [Header("GameObject prefab")]
    [SerializeField] private GameObject wallPairPrefab = default;
    [SerializeField] private GameObject floor = default;

    [SerializeField] private float wallOffset = default;
    [SerializeField] private float cameraOffset = default;

    [SerializeField] private GameObject wallPair_older;
    [SerializeField] private GameObject wallPair_newer;

    private void Update()
    {
        if(floor.transform.position.y - wallPair_older.transform.position.y > wallOffset - cameraOffset)
        {
            GenerateWalls();
        }
    }

    private void GenerateWalls()
    {
        float posY = wallPair_newer.transform.position.y + wallOffset;
        Vector3 pos = new Vector3(0, posY, 0);

        GameObject wallPair_toDestroy = wallPair_older;

        wallPair_older = wallPair_newer;
        wallPair_newer = Instantiate(wallPairPrefab, pos, Quaternion.identity, transform);

        Destroy(wallPair_toDestroy);
    }
}
