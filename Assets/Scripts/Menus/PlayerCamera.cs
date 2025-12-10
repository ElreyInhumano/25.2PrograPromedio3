using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float sensX, sensY, speed;
    [SerializeField] private Transform orientation;
    [SerializeField] private GameObject player;
    float xRotation, yRotation;
    void Start()
    {
        
    }
    void Update()
    {
        Mouse();
    }

    void Mouse()
    {

        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        player.transform.localRotation = Quaternion.Euler(0, yRotation, 0);
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * speed * Time.deltaTime;
        player.transform.Translate(move);
    }
}
