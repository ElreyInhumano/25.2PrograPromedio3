using UnityEngine;

public class BossPhase1 : IBossStrategy
{
    protected GameObject player;
    protected Rigidbody rb;
    protected Transform bossTransform;
    [SerializeField] PlayerLife playerLife;
    [SerializeField] protected float bossSpeed;
    [SerializeField] protected float bossLife;
    [SerializeField] protected float radius;
    public BossPhase1(GameObject player, Rigidbody rb, Transform bossTransform, float bossSpeed, float bossLife, float radius)
    {
        this.player = player;
        this.rb = rb;
        this.bossSpeed = bossSpeed;
        this.bossLife = bossLife;
        this.bossTransform = bossTransform;
        this.radius = radius;
    }
    public void BossPhase()
    {
        float distanceToPlayer = Vector3.Distance(bossTransform.position, player.transform.position);
        if (distanceToPlayer >= radius)
        {
            Vector3 direction = player.transform.position - bossTransform.position;
            direction.y = 0;
            direction = direction.normalized;
            direction *= bossSpeed;
            direction.y = rb.linearVelocity.y;
            rb.linearVelocity = direction;
            bossTransform.rotation = Quaternion.LookRotation(player.transform.position - bossTransform.position);
            BossManager.shootBoss = false;
        }
        else if (distanceToPlayer < radius)
        {
            Vector3 direction = player.transform.position - bossTransform.position;
            direction.y = 0;
            direction = direction.normalized;
            direction *= bossSpeed * 0;
            direction.y = rb.linearVelocity.y;
            rb.linearVelocity = direction;
            bossTransform.rotation = Quaternion.LookRotation(player.transform.position - bossTransform.position);
            BossManager.shootBoss = true;
        }
    }
}
