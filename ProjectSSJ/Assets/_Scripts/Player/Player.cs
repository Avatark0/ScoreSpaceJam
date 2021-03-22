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

    [SerializeField] private Rigidbody2D FloorRigBody=default;

    [SerializeField] private GameObject floor=default;
    [SerializeField] private GameObject roof=default;
    
    [SerializeField] private GameObject playerButt = default;
    [SerializeField] private GameObject shieldSprite = default;

    [SerializeField] private float invensibilityTime = default;

    [SerializeField] private int lifePoints = 1;

    private bool invensibilityFrames = false;
    public bool shieldDamageFrames = false;

    void Update()
    {
        Movement();

        VerticalSpeedLimit();
        invensibilityTimeControl();

        //PositioningSafeFix();
        
        Shoot();
        Boost();
        Pause();
    }

    private void Movement()
    {
        Vector3 pos = transform.position;
        AudioSource wings = GameObject.Find("Audio-Wings").GetComponent<AudioSource>();
        wings.pitch /= 1.01f;
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            Vector2 force = Vector2.zero;
            force.y += moveSpeedY * Time.deltaTime;
            rigBody.AddForce(force);
            wings.pitch += 0.01f;
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
        if(rigBody.velocity.y > verticalSpeedLimit + FloorRigBody.velocity.y)
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

        invensibilityFrames = false;
        shieldDamageFrames = false;

        canvasControler.GameOver();
    }

    public void TakeDamage()
    {
        if(!invensibilityFrames)
        {
            if(playerButt.GetComponent<PlayerButt>().FireflyLife())
            {
                invensibilityFrames=true;
                
                AudioSource.PlayClipAtPoint(fireflyEffect, transform.position);
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

    private void PositioningSafeFix()
    {
        Vector2 floorPos = floor.transform.position;
        Vector2 roofPos = roof.transform.position;

        if(Mathf.Abs(transform.position.magnitude - (floorPos + roofPos).magnitude) < 100)//3.4 == sheredder position offset
        {
            Vector2 pos = GameObject.FindWithTag("Repositioner").transform.position; 
            transform.position = pos;
        }
    }
}
