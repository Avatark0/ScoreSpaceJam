using UnityEngine;

public class PlatformParent : MonoBehaviour
{
    [SerializeField] private GameObject platform = default;
    [SerializeField] private GameObject floor = default;

    [SerializeField] private float limitLeft = default;
    [SerializeField] private float limitRight = default;

    //[SerializeField] private float platformOffset = default;
    [SerializeField] private float roofOffset = default;

    //[SerializeField] private float nextDifRamp = 100;
    //[SerializeField, Range(1,0)] private float difIncreaseTax = 0.8f; 

    //private float lastPlatformPos = 0;

    void Update()
    {
        if(GlobalSpawner.IsTimeForPlatform()) {
            GeneratePlatform();
        }
    }

    private void GeneratePlatform()
    {
        float[] rands = GlobalSpawner.NextPlatform();
        float posX = rands[0] * (limitRight-limitLeft) + limitLeft;
        float posY = floor.transform.position.y + roofOffset;
        Vector3 pos = new Vector3(posX, posY, 0);

        Instantiate(platform, pos, Quaternion.identity, transform);
    }
}
