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
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip lifeDecreaseSound;
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
        if (Num == pos.Length)
        {
            Destroy(gameObject);
            SpawnManager._Instance.enemies.Remove(this);
            Scene_InGame._Instance.life -= 1;
            SoundManager._Instance.SFXPlay("lifeDecrease", lifeDecreaseSound);
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

        SoundManager._Instance.SFXPlay("Hit", hitSound);

        if (enemyData.name == "kim")
        {
            if (speed > 7)
                return;
            speed += 0.2f;
        }
        if (health <= 0)
        {
            SpawnManager._Instance.enemies.Remove(this);
            Destroy(gameObject);
            SpawnManager._Instance.enemyKillCount += 1;
            Scene_InGame._Instance.money += 20;

            if(enemyData.name == "kim" || enemyData.name == "hur" || enemyData.name == "gi")
                SpawnManager._Instance.maxSpawnDelay -= 0.15f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            OnHit(bullet.dmg);
        }
    }
}
