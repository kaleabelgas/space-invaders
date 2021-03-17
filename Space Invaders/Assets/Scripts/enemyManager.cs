using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManager : MonoBehaviour
{

    playerController player;
    public int enemyHealth = 100;
    public int enemyPoint = 5;
    public float enemyCollisionDamage = 20;
    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;
        //Debug.Log(enemyHealth);

        if (enemyHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        FindObjectOfType<Scoring>().AddScore(enemyPoint);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D hitPlayer)
    {
        player = hitPlayer.GetComponent<playerController>();
        if (player != null)
        {
            
            Destroy(gameObject);
            player.PlayerDamage(enemyCollisionDamage);
        }
        Debug.Log(hitPlayer.name);
    }



}
