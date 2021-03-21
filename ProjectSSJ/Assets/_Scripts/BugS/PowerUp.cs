using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private GameObject playerButt = default;
    [SerializeField] private Rigidbody2D rigBody = default;

    private float translationSpeed = 2;
    private bool inButt;
    public bool translate;

    private Vector3 finalPos = new Vector3();
    private Vector3 translationVector = new Vector3();

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
        TranslateToButt();
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

    private void TranslateToButt()
    {
        if(translate)
        {
            Vector3 ini = transform.position;
            Vector3 end = playerButt.transform.position;

            translationVector = (end - ini) * translationSpeed;

            transform.Translate(translationVector * Time.deltaTime);

            if(translationVector.magnitude < playerButt.GetComponent<PlayerButt>().GetProximityThereshold())
            {
                translate = false;
                playerButt.GetComponent<PlayerButt>().IncreaseProximityThreshold();
            }
        }
    }

    private void StartTranslation()
    {
        translate = true;
    }

    public void SetPlayerObj(GameObject _playerButt)
    {
        playerButt = _playerButt;
    }

    public string BugName()
    {
        return gameObject.name;
    }
}
