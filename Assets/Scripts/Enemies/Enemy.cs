using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected GameObject player;
    protected Rigidbody rb;
    [SerializeField] protected float enemySpeed;
    [SerializeField] protected float life;
    [SerializeField] protected bool kamikaze;
    [SerializeField] protected float radius;
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
    }

    protected virtual void EnemyMovement() { }

    protected virtual void Update()
    {
        if(life <= 0)
        {
            AutoDestroy();
        }
    }

    protected virtual void AutoDestroy()
    {
        Levels.enemiesKilled += 1;
        Levels.enemiesKilledTotal += 1;
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(kamikaze) AutoDestroy();


        }
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arm"))
        {
            if(Input.GetMouseButtonDown(0)) life -= 1;

        }
    }
    protected virtual void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Arm"))
        {
            if(Input.GetMouseButtonDown(0)) life -= 1;

        }
    }
}
