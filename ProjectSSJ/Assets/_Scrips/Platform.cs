using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private GameObject platform = default;
    [SerializeField] private GameObject floor = default;

    [SerializeField] private float limitLeft = default;
    [SerializeField] private float limitRight = default;

    [SerializeField] private float verticalPlatformOffset = default;
    [SerializeField] private float verticalRoofOffset = default;

    private float lastPlatformPos = 0;

    void Update()
    {
        if(floor.transform.position.y - lastPlatformPos > verticalPlatformOffset)
        {
            CreatePlatform();
            lastPlatformPos=floor.transform.position.y;
        }
    }

    private void CreatePlatform()
    {
        float posX = Random.Range(limitLeft,limitRight);
        float posY = floor.transform.position.y + verticalRoofOffset;
        Vector3 pos = new Vector3(posX, posY, 0);

        Instantiate(platform, pos, Quaternion.identity, transform);
    }
}
