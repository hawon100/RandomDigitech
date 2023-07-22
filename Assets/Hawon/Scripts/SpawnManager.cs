using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager _Instance { get; private set; }

    public GameObject enemyObj;

    [SerializeField] private Transform[] pos;

    public List<Enemy> enemies = new List<Enemy>();

    public int enemyCount;

    private void Awake()
    {
        _Instance = this;
    }

    private void Start()
    {
        SpawnWave();
    }

    void SpawnWave()
    {
        CreateEnemy();
    }

    void CreateEnemy()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            transform.position = pos[0].transform.position;

            GameObject enemy = Instantiate(enemyObj, pos[0].position, Quaternion.identity);
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
        }
    }
}
