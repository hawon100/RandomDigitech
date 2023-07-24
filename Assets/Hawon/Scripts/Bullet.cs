using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int dmg; 

    private void Update()
    {
        Destroy(gameObject, 5f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch(collision.gameObject.name)
        {
            case "Grapic": dmg = 1; break;
            case "Programming": dmg = 5; break;
            case "Plan": dmg = 3; break;
            case "None": dmg = 0; break;
            case "Study": dmg = 6; break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
