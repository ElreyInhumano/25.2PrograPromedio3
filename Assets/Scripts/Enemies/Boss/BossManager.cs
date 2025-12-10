using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;
public class BossManager : MonoBehaviour
{
    protected GameObject player;
    protected Rigidbody rb;
    [SerializeField] protected float bossSpeed, bossSpeedPhase4;
    [SerializeField] protected float bossLife;
    [SerializeField] protected int phase;
    [SerializeField] protected float radius, maxTimer;
    [SerializeField] float timer, timerPhase3;
    [SerializeField] private GameObject prefabBullet;
    [SerializeField] private GameObject shootPoint;
    [SerializeField] PlayerLife playerLife;
    public static bool shootBoss;
    public static bool atackBoss;
    public IBossStrategy currentStrategy;
    private static BossManager instance;
    public event Action<int> OnProgressionChanged;
    public static bool time;
    public static bool backToSpawn;
    [SerializeField] private int progression;
    SpawnEnemies spawn;
    private void Awake()
    {
        instance = this;
        currentStrategy = new BossPhase1(player, rb, transform, bossSpeed, bossLife, radius);
    }

    public static BossManager GetInstance()
    {
        return instance;
    }
    void Start()
    {
        backToSpawn = true;
        shootBoss = false;
        time = false;
        phase = UnityEngine.Random.Range(1, 5);
        rb = GetComponent<Rigidbody>();
        spawn = GameObject.Find("SpawnEnemies").GetComponent<SpawnEnemies>();
        player = GameObject.FindWithTag("Player");
        playerLife = player.GetComponent<PlayerLife>();
        StartCoroutine(StrategyManager());
        SpawnEnemies.timerBoss = 0;
        if(phase == 3)
        {
            currentStrategy.BossPhase();
        }
    }

    void Update()
    {
        if (bossLife <= 0)
        {
            AutoDestroy();
        }
        currentStrategy.BossPhase();
        if (shootBoss)
        {
            timer += Time.deltaTime;
            if (timer >= maxTimer)
            {
                ShootBullet();
                timer = 0;
            }
        }
        if (atackBoss)
        {
            timer += Time.deltaTime;
            if (timer >= maxTimer)
            {
                Attack();
                timer = 0;
            }
        }
        ChangeTimer();
        if (backToSpawn)
        {
            spawn.SpawnBoss(gameObject);
        }
    }
    void ChangeTimer()
    {
        if (time)
        {
            Debug.Log($"time{time}");
            timerPhase3 += Time.deltaTime;
            if (timerPhase3 >= 2)
            {
                progression++;
                OnProgressionChanged(progression);
                timerPhase3 = 0;
            }
        }
    }
    private void AutoDestroy()
    {
        Levels.enemiesKilledTotal += 1;
        SpawnEnemies.bossExist = false;
        Destroy(gameObject);
    }

    IEnumerator StrategyManager()
    {
        currentStrategy = new BossPhase1(player, rb, transform, bossSpeed, bossLife, radius);
        while (phase == 1)
        {
            yield return null;
        }
        currentStrategy = new BossPhase2(player, rb, transform, bossSpeed, bossLife, radius);
        while (phase == 2)
        {
            yield return null;
        }
        currentStrategy = new BossPhase3(player, rb, transform, bossSpeed, bossLife, radius, transform.localScale);
        while (phase == 3)
        {
            yield return null;
        }
        currentStrategy = new BossPhase1(player, rb, transform, bossSpeedPhase4, bossLife, radius);
        while (phase == 4)
        {
            yield return null;
        }
    }

    public void ShootBullet()
    {
        Instantiate(prefabBullet, shootPoint.transform.position, new Quaternion(0, transform.rotation.y, 0, transform.rotation.w));
    }

    void Attack()
    {
        PlayerLife.life = playerLife.lifeF(PlayerLife.life, 1);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(phase == 4)
            {
                bossLife -= 1;
                backToSpawn = true;
            }
            else
            {
                AutoDestroy();
            }
           
        }
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arm"))
        {
            if (Input.GetMouseButtonDown(0)) bossLife -= 1;
        }
    }
    protected virtual void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Arm"))
        {
            if (Input.GetMouseButtonDown(0)) bossLife -= 1;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
