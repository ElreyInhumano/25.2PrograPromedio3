using UnityEngine;

public class BulletPlayer : Bullets
{
    private float timer;
    [SerializeField] private float maxTimer;

    void Update()
    {
        AutoDestroy();
        BulletMovement();
    }

    protected override void BulletMovement()
    {
        //rb.AddForce(transform.forward * bulletSpeed, ForceMode.Force);
        rb.linearVelocity = bulletSpeed * transform.forward;
    }
    protected override void AutoDestroy()
    {
        timer += Time.deltaTime;
        if(timer >= maxTimer)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Boss"))
        {
            Destroy(gameObject);
        }
    }
}
