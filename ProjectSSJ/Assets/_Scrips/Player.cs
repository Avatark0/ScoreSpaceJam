using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CanvasControler canvasControler=default;

    [SerializeField] private Rigidbody2D rigBody=default;
    [SerializeField] private float moveSpeedX=default;
    [SerializeField] private float moveSpeedY=default;

    void Update()
    {
        Vector3 pos = transform.position;
        if(Input.GetKey(KeyCode.W))
        {
            //pos.y+=moveSpeedY*Time.deltaTime;
            //transform.position=pos;

            Vector2 force = Vector2.zero;
            force.y += moveSpeedY * Time.deltaTime;
            rigBody.AddForce(force);
        }
        if(Input.GetKey(KeyCode.S))
        {
            //pos.y-=moveSpeedY*Time.deltaTime;
            //transform.position=pos;
        }
        if(Input.GetKey(KeyCode.A))
        {
            pos.x-=moveSpeedX*Time.deltaTime;
            transform.position=pos;
        }
        if(Input.GetKey(KeyCode.D))
        {
            pos.x+=moveSpeedX*Time.deltaTime;
            transform.position=pos;
        }
    }

    private void OnDestroy()
    {
        canvasControler.GameOver();
    }
}
