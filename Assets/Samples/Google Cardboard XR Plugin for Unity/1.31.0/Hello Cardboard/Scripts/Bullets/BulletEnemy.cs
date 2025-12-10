using UnityEngine;

public class BulletEnemy : Bullets
{
    void Update()
    {
        BulletMovement();
    }

    protected override void BulletMovement()
    {
        //rb.AddForce(transform.forward * bulletSpeed, ForceMode.Force);
        rb.linearVelocity = bulletSpeed * transform.forward;
    }
    protected override void AutoDestroy()
    {
        Destroy(gameObject);        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AutoDestroy();
        }
    }
}
