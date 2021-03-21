using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CanvasControler canvasControler = default;
    [SerializeField] private AudioManager audioManager = default;

    [SerializeField] private Rigidbody2D rigBody=default;
    [SerializeField] private float moveSpeedX=default;
    [SerializeField] private float moveSpeedY=default;
    
    [SerializeField] private GameObject bullet = default;
    [SerializeField] private GameObject bulletParent = default;

    void Update()
    {
        Movement();
        Shoot();
    }

    private void Movement()
    {
        Vector3 pos = transform.position;

        if(Input.GetKey(KeyCode.W))
        {
            Vector2 force = Vector2.zero;
            force.y += moveSpeedY * Time.deltaTime;
            rigBody.AddForce(force);
        }
        if(Input.GetKey(KeyCode.S))
        {
            Vector2 force = Vector2.zero;
            force.y -= moveSpeedY * Time.deltaTime * 0.5f;
            rigBody.AddForce(force);
        }
        if(Input.GetKey(KeyCode.A))
        {
            pos.x-=moveSpeedX*Time.deltaTime;
            transform.position=pos;

            rigBody.velocity = new Vector2(0, rigBody.velocity.y);
        }
        if(Input.GetKey(KeyCode.D))
        {
            pos.x+=moveSpeedX*Time.deltaTime;
            transform.position=pos;

            rigBody.velocity = new Vector2(0, rigBody.velocity.y);
        }
    }

    private void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position, Quaternion.identity, bulletParent.transform);
        }
    }

    private void OnDestroy()
    {
        if(audioManager==null)
            audioManager=GameObject.Find("AudioManager").GetComponent<AudioManager>();
        audioManager.ResetChildrenValues();

        canvasControler.GameOver();
    }
}
