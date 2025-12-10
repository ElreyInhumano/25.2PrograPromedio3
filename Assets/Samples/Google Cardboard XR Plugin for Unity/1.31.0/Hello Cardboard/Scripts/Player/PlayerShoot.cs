using UnityEngine;

public class PlayerShoot : MonoBehaviour, IShootBullet
{
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject prefabBullet;
    [SerializeField] private GameObject shootPoint;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ShootBullet();

        }

        RotateToMouse();
        
    }

    void RotateToMouse()
    {
        Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.y = 0;

        transform.forward = mousePosition - transform.position;

    }

    public void ShootBullet()
    {
        Instantiate(prefabBullet, shootPoint.transform.position, new Quaternion(0,transform.rotation.y,0,transform.rotation.w));
    }
}
