using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CanvasControler canvasControler = default;
    [SerializeField] private AudioManager audioManager = default;

    [SerializeField] private Rigidbody2D rigBody=default;
    [SerializeField] private float moveSpeedX=default;
    [SerializeField] private float moveSpeedY=default;
    
    [SerializeField] private GameObject playerButt = default;

    void Update()
    {
        Movement();
        Shoot();
        Pause();
    }

    private void Movement()
    {
        Vector3 pos = transform.position;

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            Vector2 force = Vector2.zero;
            force.y += moveSpeedY * Time.deltaTime;
            rigBody.AddForce(force);
        }
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            Vector2 force = Vector2.zero;
            force.y -= moveSpeedY * Time.deltaTime * 0.5f;
            rigBody.AddForce(force);
        }
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            pos.x-=moveSpeedX*Time.deltaTime;
            transform.position=pos;

            rigBody.velocity = new Vector2(0, rigBody.velocity.y);
        }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
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
            playerButt.GetComponent<PlayerButt>().Shoot();
        }
    }

    private void Pause()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            CanvasControler.Pause();
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
