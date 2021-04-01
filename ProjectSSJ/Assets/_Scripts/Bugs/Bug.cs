using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bug : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] protected GameObject acidBubble;
    [SerializeField] protected Rigidbody2D myRB = default;
    [Header("Controls")]
    [SerializeField] protected float fall_speed = default;
    [SerializeField] protected State myState;
    [Header("Instances")]
    [SerializeField] protected GameObject playerButt = default;

    protected enum State
    {
        falling,
        stoped,
        merging,
        inButt,
        skill
    }

    private float translationSpeed = 2;

    public abstract void Effect();

    private void Update()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(gameObject.tag == "Bug" && other.gameObject.tag == "PlayerButt")
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
            other.gameObject.GetComponent<Bug>().AttachToPlayerButt();
        }
        else if(other.gameObject.tag == "Platform")
        {
            myState = State.stoped;
            transform.parent = other.gameObject.transform;
        }
    }

    public void AttachToPlayerButt()
    {
        myState = State.merging;
        
        acidBubble.SetActive(false);
        myRB.simulated=false;
        
        transform.parent = playerButt.transform;
        transform.rotation=Quaternion.identity;

        gameObject.tag = "PlayerButt";

        playerButt.GetComponent<PlayerButt>().CatchBug(gameObject);

        GetComponentInChildren<BugSoundEffects>().PickedUpSound();
    }

    public void Death()
    {
        GetComponentInChildren<BugSoundEffects>().DyingSound();

        if(myState == State.inButt)
            playerButt.GetComponent<PlayerButt>().LoseBug(gameObject);

        Destroy(gameObject);
    }

    private void Move()
    {
        Vector3 translationVector = new Vector3();

        if(myState == State.falling)
        {
            Vector3 pos = transform.position;
            pos.y -= (fall_speed + ScrollController.GetScrollSpeed()) * Time.deltaTime;
            transform.position=pos;

            transform.Rotate(0, 0, 60*Time.deltaTime, Space.Self);
        }
        else if(myState == State.merging)
        {
            Vector3 ini = transform.position;
            Vector3 end = playerButt.transform.position;

            translationVector = (end - ini) * translationSpeed;

            transform.Translate(translationVector * Time.deltaTime);

            if(translationVector.magnitude < playerButt.GetComponent<PlayerButt>().GetProximityThereshold())
            {
                myState = State.inButt;
                playerButt.GetComponent<PlayerButt>().IncreaseProximityThreshold();
            }
        }
    }

    public void SetPlayerObj(GameObject _playerButt)
    {
        playerButt = _playerButt;
    }
}
