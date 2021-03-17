using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManager : MonoBehaviour
{
    public static enemyManager EMInstance;

    public int enemyHealth = 100;
    public int enemyPoint = 5;
    public float enemyCollisionDamage = 20;

    private void Start()
    {
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
