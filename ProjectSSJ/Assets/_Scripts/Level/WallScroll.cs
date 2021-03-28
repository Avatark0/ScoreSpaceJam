using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScroll : MonoBehaviour
{
    [Header("GameObject prefab")]
    [SerializeField] private GameObject wallPairPrefab = default;
    [Header("Adjustments")]
    [SerializeField] private float wallOffset = default;
    [SerializeField] private float cameraOffset = default;
    [Header("Instances")]
    [SerializeField] private GameObject wallPair_older;
    [SerializeField] private GameObject wallPair_newer;

    private void Update()
    {
        if(wallPair_older.transform.position.y <= wallOffset - cameraOffset)
        {
            GenerateWalls();
        }
    }

    private void GenerateWalls()
    {
        float posY = wallPair_newer.transform.position.y - wallOffset;
        Vector3 pos = new Vector3(0, posY, 0);

        GameObject wallPair_toDestroy = wallPair_older;

        wallPair_older = wallPair_newer;
        wallPair_newer = Instantiate(wallPairPrefab, pos, Quaternion.identity, transform);

        Destroy(wallPair_toDestroy);
    }
}
