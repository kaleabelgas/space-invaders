using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletManager : MonoBehaviour
{

    enemyManager enemy;
    public GameObject hitEffectPrefab;
    public Camera cam;
    public int damage = 5;
    private void OnTriggerEnter2D(Collider2D hitEnemy)
    {
        
        enemy = hitEnemy.GetComponent<enemyManager>();
        GameObject hEffect = Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
        Destroy(hEffect, 2);
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            
        }
        

        Destroy(gameObject);
        //Debug.Log(hitEnemy.name);
        //Debug.Log("ouch");
    }
}
