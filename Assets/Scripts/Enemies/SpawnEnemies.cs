using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawnpoints = new List<GameObject>();
    [SerializeField] private List<GameObject> enemies = new List<GameObject>();
    [SerializeField] private List<int> fibonacci = new List<int>();
    [SerializeField] private GameObject boss;
    int indexSpawn, indexEnemies, fibonacciIndex, a = 0, b = 1;
    public static int spawnCount;
    public static bool bossExist;
    Coroutine coroutine;
    bool spawnEnemy, startCoroutine;
    float timer;
    public static float timerBoss;
    void Start()
    {
        Fibonacci();
        coroutine = StartCoroutine(StartSpawn(fibonacci[Levels.level], 0.19f));
    }

    void Update()
    {
        //ChooseSpawnPoints();
        ChangeLevel();
        if (spawnEnemy)
        {
            Spawn();
        }
        if (Levels.startLevel)
        {
            EffectAnimation();
        }
        if (!bossExist)
        {
            timerBoss += Time.deltaTime;
            if (timerBoss >= 5)
            {
                //Instantiate(boss,transform.position,transform.rotation);
                //SpawnBoss(boss);
                bossExist = true;
                timer = 0;
            }
        }
    }

    void Fibonacci()
    {
        for(int i = 0; i<10; i++)
        {
            if(i <= 1)
            {
                fibonacciIndex = i;
            }
            else
            {
                fibonacciIndex = a + b;
                a = b;
                b = fibonacciIndex;
            }
            fibonacci.Add(fibonacciIndex);
        }
    }

    void ChangeLevel()
    {
        if(Levels.enemiesKilled == fibonacci[Levels.level])
        {
            Levels.level += 1;
            Levels.enemiesKilled = 0;
            Levels.startLevel = true;
            spawnCount = 0;
        }
    }
    void EffectAnimation()
    {
        /*if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }*/
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            Levels.startLevel = false;

            /*if (coroutine != null)
            {
                StopCoroutine(coroutine);
            }*/
            timer = 0;
        }
    }
    public void SpawnBoss(GameObject boss)
    {
        boss.transform.position = spawnpoints[indexSpawn].transform.position;
        BossManager.backToSpawn = false;
    }
    private IEnumerator StartSpawn(int effectAmount, float timeBetweenEffects)
    {
        while (!startCoroutine)
        {
            if (Levels.startLevel)
            {
                for ( spawnCount = 0; spawnCount < fibonacci[Levels.level]; spawnCount++)
                {
                    Debug.Log(fibonacci[Levels.level]);
                    Debug.Log(spawnCount);
                    indexSpawn = Random.Range(0, spawnpoints.Count);
                    indexEnemies = Random.Range(0, enemies.Count);
                    spawnEnemy = true;
                    yield return new WaitForSeconds(timeBetweenEffects);
                }
            }
            yield return new WaitForSeconds(timeBetweenEffects);
        }
    }
    void Spawn()
    {
        spawnEnemy = false;
        Instantiate(enemies[indexEnemies], spawnpoints[indexSpawn].transform);
    }
}
