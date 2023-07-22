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
            return;
        }

        Debug.Log(Num);

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
            Destroy(gameObject);
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
