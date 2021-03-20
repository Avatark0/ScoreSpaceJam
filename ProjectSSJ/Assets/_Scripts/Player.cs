using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CanvasControler canvasControler = default;

    [SerializeField] private Rigidbody2D rigBody=default;
    [SerializeField] private float moveSpeedX=default;
    [SerializeField] private float moveSpeedY=default;

    void Update()
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

    private void OnDestroy()
    {
        canvasControler.GameOver();
    }
}
