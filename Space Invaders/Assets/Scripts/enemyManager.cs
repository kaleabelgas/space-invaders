using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManager : MonoBehaviour
{
    public static enemyManager EMInstance;

    public int enemyHealth;
    public int enemyPoint = 5;
    public float enemyCollisionDamage = 20;

    public GameObject deathEffect;

    private void Start()
    {
        enemyHealth = enemySpawner.enemySpawnerInstance.defaultEnemyHealth;
        EMInstance = this;
    }

    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;
        cameraShake.instance.initializeShake(0.1f, 0.12f);

        //Debug.Log(enemyHealth);

        if (enemyHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Scoring.scoringInstance.AddScore(enemyPoint);
        GameObject dEffect = Instantiate(deathEffect, transform.position, transform.rotation);
        cameraShake.instance.initializeShake(0.2f, 0.15f);
        Destroy(dEffect, 2);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D hitPlayer)
    {
        playerController.pcInstance = hitPlayer.GetComponent<playerController>();
        if (playerController.pcInstance != null)
        {
            playerController.pcInstance.PlayerDamage(enemyCollisionDamage);
            Destroy(gameObject);
            //camShake.initializeShake(0.5f, 1f);
        }
        Debug.Log(hitPlayer.name);
    }



}
