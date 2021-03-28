using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [Header("GameObject prefabs")]
    [SerializeField] private GameObject backgroundPrefab = default;
    [Header("Adjustments")]
    [SerializeField] private float backgroundOffset = default;
    [SerializeField] private float screenOffset = default;
    [Header("Instances")]
    [SerializeField] private GameObject background_older;
    [SerializeField] private GameObject background_newer;

    private void Update()
    {
        if(background_older.transform.position.y <= backgroundOffset - screenOffset)
        {
            GenerateWalls();
        }
    }

    private void GenerateWalls()
    {
        float posY = background_newer.transform.position.y - backgroundOffset;
        Vector3 pos = new Vector3(0, posY, 0);

        GameObject background_toDestroy = background_older;

        background_older = background_newer;
        background_newer = Instantiate(backgroundPrefab, pos, Quaternion.identity, transform);

        Destroy(background_toDestroy);
    }
}
