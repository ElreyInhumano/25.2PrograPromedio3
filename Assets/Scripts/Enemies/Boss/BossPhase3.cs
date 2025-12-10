using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class BossPhase3 : IBossStrategy
{
    protected GameObject player;
    protected Rigidbody rb;
    protected Transform bossTransform;
    [SerializeField] protected float bossSpeed;
    [SerializeField] protected float bossLife;
    [SerializeField] protected float radius;
    [SerializeField] protected bool subscribed;
    [SerializeField] protected int progression;
    [SerializeField] protected Vector3 bossScale;
    public BossPhase3(GameObject player, Rigidbody rb, Transform bossTransform,
        float bossSpeed, float bossLife, float radius, Vector3 bossScale)
    {
        this.player = player;
        this.rb = rb;
        this.bossSpeed = bossSpeed;
        this.bossLife = bossLife;
        this.bossTransform = bossTransform;
        this.radius = radius;
        this.bossScale = bossScale;
    }
    
    public void BossPhase()
    {
        if (!subscribed)
        {
            BossManager.GetInstance().OnProgressionChanged += Attack;
            subscribed = true;
        }
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
                       
            BossManager.time = true;
            bossTransform.localScale = bossScale;
            if(bossLife <= 0)
            {
                BossManager.GetInstance().OnProgressionChanged -= Attack;
            }
        }
        
    }

    public void Attack(int progression)
    {
         bossScale = new Vector3(progression+ bossScale.x, progression+ bossScale.y, progression+ bossScale.z);
    }
}
