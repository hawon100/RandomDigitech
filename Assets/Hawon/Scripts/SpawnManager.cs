using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager _Instance { get; private set; }

    public GameObject enemyObj;

    [SerializeField] private Transform[] pos;

    private List<Enemy> enemies = new List<Enemy>();

    private int allEnemyCount; //총 적 개수

    public int defaultEnemyCount = 2;

    public int enemyCount;

    public int addEnemyCount = 3;

    private void Awake()
    {
        _Instance = this;
    }

    private void Start()
    {
        enemyCount = defaultEnemyCount;
    }

    private void Update()
    {
        if (Scene_InGame._Instance != null)
        {
            return;
        }

        allEnemyCount = enemies.Count;

        if (allEnemyCount <= 0)
        {
            SpawnWave();
        }

    }

    void SpawnWave()
    {
        for (int i = 0; i < pos.Length; i++)
        {
            Transform spawnPoint = pos[i];

            CreateEnemy(spawnPoint);
        }
    }

    void CreateEnemy(Transform spawnPoint)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            transform.position = pos[0].transform.position;

            GameObject enemy = Instantiate(enemyObj, pos[0].position, Quaternion.identity);
            Enemy enemyLogic = enemy.GetComponent<Enemy>();

            //생성된 적을 리스트에 추가
            enemies.Add(enemyLogic);
        }
    }

    //private IEnumerator Spawn()
    //{
    //    yield return new WaitForSeconds(4f);

    //    GameObject enemy = Instantiate(enemyObj, pos[0].position, Quaternion.identity);
    //    Enemy enemyLogic = enemy.GetComponent<Enemy>();
    //    for (int i = 0; i < pos.Length; i++)
    //    {
    //        if (enemyLogic.pos[i] == null)
    //        {
    //            enemyLogic.pos[i] = pos[i];
    //        }
    //    }
    //}
}
