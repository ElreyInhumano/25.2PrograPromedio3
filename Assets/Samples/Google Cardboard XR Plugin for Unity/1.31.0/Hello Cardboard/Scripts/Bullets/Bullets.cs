using UnityEngine;

public abstract class Bullets : MonoBehaviour
{
    [SerializeField] protected float bulletSpeed;
    protected Rigidbody rb;
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    protected virtual void BulletMovement() { }
    protected virtual void AutoDestroy() { }
}
