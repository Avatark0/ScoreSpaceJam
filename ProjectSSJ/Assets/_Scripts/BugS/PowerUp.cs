using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private GameObject playerButt = default;
    [SerializeField] private Rigidbody2D rigBody = default;

    private bool inButt;

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

    public void AttachToPlayerButt()
    {
        if(!inButt)
        {
            transform.parent = playerButt.transform;

            Destroy(rigBody);
            rigBody = playerButt.GetComponentInParent<Rigidbody2D>();

            gameObject.tag = "PlayerButt";
            inButt = true;

            playerButt.GetComponent<PlayerButt>().AddBug(gameObject);

            GetComponentInChildren<BugSoundEffects>().PickedUp();
        }
    }

    public void Death()
    {
        GetComponentInChildren<BugSoundEffects>().Dying();

        if(inButt)
            playerButt.GetComponent<PlayerButt>().RemoveBug(gameObject.name);

        Destroy(gameObject);
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
