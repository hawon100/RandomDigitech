using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;
    [SerializeField] public Transform[] pos;
    [SerializeField] private float speed = 5f;
    [SerializeField] private int health;
    int Num = 0;

    private void Start()
    {
        health = enemyData.health;
        speed = enemyData.speed;
    }

    private void Update()
    {
        MovePath();
    }

    public void MovePath()
    {
        if(Num == pos.Length)
        {
            Destroy(gameObject);
            SpawnManager._Instance.enemies.Remove(this);
            Scene_InGame._Instance.life -= 1;
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, pos[Num].transform.position, speed * Time.deltaTime);

        if (transform.position == pos[Num].transform.position)
        {
            Num++;
        }
    }

    private void OnHit(int dmg)
    {
        health -= dmg;
        if(health <= 0)
        {
            SpawnManager._Instance.enemies.Remove(this);
            Destroy(gameObject);
            SpawnManager._Instance.enemyKillCount += 1;
            if (gameObject.name == "boss 0" || gameObject.name == "boss 1" || gameObject.name == "boss 2")
            {
                SpawnManager._Instance.curEnemyCount = 0;
                SpawnManager._Instance.stage += 1;
                SpawnManager._Instance.curSpawnDelay -= 0.15f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            OnHit(bullet.dmg);
        }
    }
}
