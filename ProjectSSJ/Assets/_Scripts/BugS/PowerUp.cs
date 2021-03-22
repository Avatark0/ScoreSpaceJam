using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private GameObject powerUpParent = default;
    [SerializeField] private GameObject playerButt = default;
    [SerializeField] private Rigidbody2D rigBody = default;

    [SerializeField] private float launchSpeed = default;

    private bool inButt;
    private bool translateTo;
    private bool translateOut;
    private float translationSpeed = 2;

    private Vector3 finalPos = new Vector3();
    //private Vector3 translationVector = new Vector3();

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "PlayerButt")
        {
            AttachToPlayerButt();
        }
        else if(other.gameObject.tag == "AcidDrop")
        {
            Death();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(gameObject.tag == "PlayerButt" && other.gameObject.tag == "Bug")
        {
            other.gameObject.GetComponent<PowerUp>().AttachToPlayerButt();
        }
    }

    private void Update()
    {
        Move();
    }

    public void AttachToPlayerButt()
    {
        if(!inButt)
        {
            transform.parent = playerButt.transform;

            Destroy(rigBody);
            rigBody = playerButt.GetComponentInParent<Rigidbody2D>();

            gameObject.tag = "PlayerButt";
            inButt = true;

            playerButt.GetComponent<PlayerButt>().CatchBug(gameObject);

            GetComponentInChildren<BugSoundEffects>().PickedUp();

            StartTranslation();
        }
    }

    public void Death()
    {
        GetComponentInChildren<BugSoundEffects>().Dying();

        if(inButt)
            playerButt.GetComponent<PlayerButt>().LoseBug(gameObject);

        Destroy(gameObject);
    }

    private void Move()
    {
        Vector3 translationVector = new Vector3();

        if(translateTo)
        {
            Vector3 ini = transform.position;
            Vector3 end = playerButt.transform.position;

            translationVector = (end - ini) * translationSpeed;

            transform.Translate(translationVector * Time.deltaTime);

            if(translationVector.magnitude < playerButt.GetComponent<PlayerButt>().GetProximityThereshold())
            {
                translateTo = false;
                playerButt.GetComponent<PlayerButt>().IncreaseProximityThreshold();
            }
        }
        else if(translateOut)
        {
            translationVector = Vector3.up;

            transform.Translate(translationVector * Time.deltaTime * launchSpeed);
        }
    }

    private void StartTranslation()
    {
        translateTo = true;
    }

    public void SetPlayerObj(GameObject _playerButt)
    {
        playerButt = _playerButt;
    }

    public void SetPowerUpParentObj(GameObject _powerUpParent)
    {
        powerUpParent = _powerUpParent;
    }

    public string BugName()
    {
        return gameObject.name;
    }

    public void ShootFromButt()
    {
        transform.SetParent(powerUpParent.transform);
        
        translateOut=true;
    }
}
