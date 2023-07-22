using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public Transform[] pos;
    [SerializeField] private float speed = 5f;
    int Num = 0;

    private void Update()
    {
        MovePath();
    }

    public void MovePath()
    {
        transform.position = Vector2.MoveTowards(transform.position, pos[Num].transform.position, speed * Time.deltaTime);

        if (transform.position == pos[Num].transform.position)
        {
            Num++;
        }

        if (Num == pos.Length)
        {
            Destroy(gameObject);
        }
    }
}
