using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CanvasControler canvasControler = default;
    [SerializeField] private AudioManager audioManager = default;
    [SerializeField] private AudioClip fireflyEffect = default;

    [SerializeField] private Rigidbody2D rigBody=default;
    [SerializeField] private float moveSpeedX=default;
    [SerializeField] private float moveSpeedY=default;
    [SerializeField] private float verticalSpeedLimit = default;
    
    [SerializeField] private GameObject playerButt = default;
    [SerializeField] private GameObject shieldSprite = default;

    [SerializeField] private float invensibilityTime = default;

    [SerializeField] private int lifePoints = 1;

    private bool invensibilityFrames;
    public bool shieldDamageFrames = false;

    void Update()
    {
        Movement();

        VerticalSpeedLimit();
        invensibilityTimeControl();
        
        Shoot();
        Boost();
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

    private void VerticalSpeedLimit()
    {
        if(rigBody.velocity.y > verticalSpeedLimit)
        {
            Vector2 vel = rigBody.velocity;
            vel.y = verticalSpeedLimit;
            rigBody.velocity = vel;
        }
        else if(rigBody.velocity.y < -verticalSpeedLimit/2)
        {
            Vector2 vel = rigBody.velocity;
            vel.y = -verticalSpeedLimit/2;
            rigBody.velocity = vel;
        }
    }

    private void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerButt.GetComponent<PlayerButt>().BeeShoot();
        }
    }

    private void Boost()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerButt.GetComponent<PlayerButt>().CricketBoost();
            shieldSprite.SetActive(true);
        }
    }

    private void Pause()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            canvasControler.Pause();
        }
    }

    private void OnDestroy()
    {
        if(audioManager==null)
            audioManager=GameObject.Find("AudioManager").GetComponent<AudioManager>();
        audioManager.ResetChildrenValues();

        canvasControler.GameOver();
    }

    public void TakeDamage()
    {
        if(!invensibilityFrames)
        {
            if(playerButt.GetComponent<PlayerButt>().FireflyLife())
            {
                invensibilityFrames=true;
                Vector2 pos = transform.position;
                Vector2 roofPos = GameObject.FindWithTag("Roof").transform.position;
                Vector2 floorPos = GameObject.FindWithTag("Floor").transform.position;
                pos.y = floorPos.y + (roofPos.y * 0.4f);
                transform.position = pos;
                AudioSource.PlayClipAtPoint(fireflyEffect, transform.position);

                Debug.Log("Player: got saved to pos = "+pos);
            }
            else
            {
                lifePoints--;
                if(lifePoints<=0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    private void invensibilityTimeControl()
    {
        if(invensibilityFrames)
        {
            invensibilityTime -= invensibilityTime*Time.deltaTime;

            if(invensibilityTime < 0.1f)
                invensibilityFrames = false;
        }
    }
}
