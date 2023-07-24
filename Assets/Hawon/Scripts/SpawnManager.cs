using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager _Instance { get; private set; }

    public GameObject[] bossObj;
    public GameObject[] enemyObj;

    [SerializeField] private Transform[] pos;

    public float curSpawnDelay;
    public float maxSpawnDelay;

    public List<Enemy> enemies = new List<Enemy>();

    public int enemyCount;

    public int curEnemyCount;

    public int enemyKillCount;

    private void Awake()
    {
        enemyKillCount = 0;
        curEnemyCount = 0;
        _Instance = this;
    }

    private void Update()
    {
        SpawnWave();
    }

    private void EnemyCount()
    {
        if (curEnemyCount % 30 != 0 || curEnemyCount == 0)
            return;

        for(int i = 0; i < 2; i++)
        {
            transform.position = pos[0].transform.position;

            int ran = Random.Range(0, 5);

            GameObject enemy = Instantiate(bossObj[ran], pos[0].position, Quaternion.identity);
            Enemy enemyLogic = enemy.GetComponent<Enemy>();

            for (int j = 0; j < pos.Length; j++)
            {
                if (enemyLogic.pos[j] == null)
                {
                    enemyLogic.pos[j] = pos[j];
                }
            }

            //생성된 적을 리스트에 추가
            enemies.Add(enemyLogic);

            curEnemyCount++;
        }
    }

    void SpawnWave()
    {
        EnemyCount();
        CreateEnemy();
        Delay();
    }

    void CreateEnemy()
    {
        if (curSpawnDelay < maxSpawnDelay)
            return;

        if (curEnemyCount % 30 == 0 && curEnemyCount != 0)
            return;

        for (int i = 0; i < enemyCount; i++)
        {
            transform.position = pos[0].transform.position;

            int ran = Random.Range(0, 3);

            GameObject enemy = Instantiate(enemyObj[ran], pos[0].position, Quaternion.identity);
            Enemy enemyLogic = enemy.GetComponent<Enemy>();

            for (int j = 0; j < pos.Length; j++)
            {
                if (enemyLogic.pos[j] == null)
                {
                    enemyLogic.pos[j] = pos[j];
                }
            }

            //생성된 적을 리스트에 추가
            enemies.Add(enemyLogic);

            curEnemyCount++;
        }

        curSpawnDelay = 0;
    }

    void Delay()
    {
        curSpawnDelay += Time.deltaTime;
    }
}
