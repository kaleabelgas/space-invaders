using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletManager : MonoBehaviour
{

    enemyManager enemy;
    playerController player;
    public int damage = 5;
    private void OnTriggerEnter2D(Collider2D hitEnemy)
    {
        enemy = hitEnemy.GetComponent<enemyManager>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Destroy(gameObject);
        //Debug.Log(hitEnemy.name);
        //Debug.Log("ouch");
    }
}
