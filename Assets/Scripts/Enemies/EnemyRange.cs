using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemyRange : Enemy, IShootBullet
{
    [SerializeField] protected float maxTimer;
    [SerializeField] float timer;
    [SerializeField] private GameObject prefabBullet;
    [SerializeField] private GameObject shootPoint;
    protected override void Update()
    {
        base.Update();
        EnemyMovement();
    }

    protected override void EnemyMovement()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if(distanceToPlayer >= radius)
        {
            Vector3 direction = player.transform.position - transform.position;
            direction.y = 0;
            direction = direction.normalized;
            direction *= enemySpeed;
            direction.y = rb.linearVelocity.y;
            rb.linearVelocity = direction;
            transform.rotation = Quaternion.LookRotation(player.transform.position - transform.position);
        }
        else if(distanceToPlayer < radius)
        {
            Vector3 direction = player.transform.position - transform.position;
            direction.y = 0;
            direction = direction.normalized;
            direction *= enemySpeed * 0;
            direction.y = rb.linearVelocity.y;
            rb.linearVelocity = direction;
            transform.rotation = Quaternion.LookRotation(player.transform.position - transform.position);
            timer += Time.deltaTime;
            if(timer >= maxTimer)
            {
                ShootBullet();
                timer = 0;
            }
        }
    }
    public void ShootBullet()
    {
        Instantiate(prefabBullet, shootPoint.transform.position, new Quaternion(0, transform.rotation.y, 0, transform.rotation.w));
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
