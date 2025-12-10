using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private Transform orientation;
    [SerializeField] private float speed;
    float xRotation, yRotation;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //PlayerMoves();
    }

    void PlayerMoves()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * 400;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * 400;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
        //orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        /*Vector2 direction = new Vector2(h, v);
        direction.Normalize();
        rb.linearVelocity = new Vector3(direction.x, 0, direction.y) * speed + Vector3.up * rb.linearVelocity.y;*/
        //Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * speed * Time.deltaTime;
        //move.Normalize();
        //rb.linearVelocity = new Vector3(move.x,0,move.z) * speed + Vector3.up * rb.linearVelocity.y; 
        //transform.Translate(move);
        /*Vector2 direction = orientation.forward * v + orientation.right * h;
        rb.AddForce(direction.normalized * speed * 5f, ForceMode.Force);*/
    }
}
