using UnityEngine;
using System.Collections;
public class EnemyMelee : Enemy
{
    [SerializeField] protected float maxTimer;
    [SerializeField] float timer;
    [SerializeField] bool inRange;
    [SerializeField] PlayerLife playerLife;

    protected override void Start()
    {
        base.Start();
        playerLife = player.GetComponent<PlayerLife>();
        StartCoroutine(Attacking());
    }
    protected override void Update()
    {
        base.Update();
        EnemyMovement();
    }

    protected override void EnemyMovement()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer >= radius)
        {
            timer = 0;
            Vector3 direction = player.transform.position - transform.position;
            direction.y = 0;
            direction = direction.normalized;
            direction *= enemySpeed;
            direction.y = rb.linearVelocity.y;
            rb.linearVelocity = direction;
            transform.rotation = Quaternion.LookRotation(player.transform.position - transform.position);
            inRange = false;
           // StopAllCoroutines(); 
        }
        else if (distanceToPlayer < radius)
        {
            Vector3 direction = player.transform.position - transform.position;
            direction.y = 0;
            direction = direction.normalized;
            direction *= enemySpeed * 0;
            direction.y = rb.linearVelocity.y;
            rb.linearVelocity = direction;
            transform.rotation = Quaternion.LookRotation(player.transform.position - transform.position);
            inRange = true;
            
            
        }
    }
    IEnumerator Attacking()
    {
        while (true)
        {
            yield return null;
            while (inRange)
            {
                yield return new WaitForSeconds(maxTimer);
                Attack();
            }
        }
        
        
    }
    void Attack()
    {
        PlayerLife.life = playerLife.lifeF(PlayerLife.life, 1);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
