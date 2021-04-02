using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Managers (Set in Hierarchy)")]
    [SerializeField] private CanvasControler canvasControler = default;
    [SerializeField] private AudioManager audioManager = default;
    [Header("Player Parts")]
    [SerializeField] private GameObject playerButt = default;
    [SerializeField] private GameObject shieldSprite = default;
    [Header("Movement Controls")]
    [SerializeField] private float moveSpeedX = default;
    [SerializeField] private float moveSpeedY = default;
    [SerializeField] private float fallSpeed = default;
    [SerializeField] private float invensibilityTime = default;
    [SerializeField] private float damageSpeedBoost = default;
    [Header("Player Stats")]
    [SerializeField] private int lifePoints = 1;
    [SerializeField] public bool invensibilityFrames = false;
    [SerializeField] public bool shieldDamageFrames = false;
    [SerializeField] public float invensibilityTimeCounter;

    private void Start()
    {
        ResetVariableValues();
    }

    void Update()
    {
        Pause();
        if(!CanvasControler.IsPaused())
        {
            Movement();
            Shoot();
            Boost();

            InvensibilityTimeControl();
        }
    }

    private void Pause()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            canvasControler.Pause();
        }
    }

    private void Movement()
    {
        Vector3 pos = transform.position;
        AudioSource wings = GameObject.Find("Audio-Wings").GetComponent<AudioSource>();
        
        wings.pitch /= 1.01f;

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            pos.y += moveSpeedY * Time.deltaTime;

            wings.pitch += 0.01f;
        }
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            pos.y -= moveSpeedY * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            pos.x -= moveSpeedX * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            pos.x += moveSpeedX * Time.deltaTime;
        }

        pos.y -= fallSpeed * Time.deltaTime;
        transform.position = pos;
    }

    private void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerButt.GetComponent<PlayerButt>().UseBee();
        }
    }

    private void Boost()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerButt.GetComponent<PlayerButt>().UseCricket();
            shieldSprite.SetActive(true);
        }
    }

    private void InvensibilityTimeControl()
    {
        if(invensibilityFrames)
        {
            invensibilityTimeCounter -= invensibilityTime * Time.deltaTime;

            Vector3 pos = transform.position;
            pos.y += damageSpeedBoost * Time.deltaTime;
            transform.position = pos;

            if(invensibilityTimeCounter <= 0)
            {
                invensibilityFrames = false;
                invensibilityTimeCounter = invensibilityTime;
            }
        }
    }

    public void TakeDamage()
    {
        if(!invensibilityFrames)
        {
            invensibilityFrames = true;

            if(!playerButt.GetComponent<PlayerButt>().UseFirefly())
            {
                lifePoints--;

                if(lifePoints<=0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    private void OnDestroy()
    {
        audioManager=GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
        
        if(audioManager != null)
            audioManager.ResetChildrenValues();

        canvasControler.GameOver();
    }

    private void ResetVariableValues()
    {
        invensibilityTimeCounter = invensibilityTime;
        invensibilityFrames = false;
        shieldDamageFrames = false;
    }
}
