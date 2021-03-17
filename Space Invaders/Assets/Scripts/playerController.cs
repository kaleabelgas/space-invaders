using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    public Rigidbody2D playerRB;
    public Transform firepoint;
    public Scoring scoringSystem;

    public float moveSpeed;
    public float playerHealth = 100f;
    private Vector2 moveDirection;


    private void Update()
    {
        moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        playerRB.MovePosition(playerRB.position + moveDirection * moveSpeed * Time.deltaTime);
    }

    public void PlayerDamage(float collisionDamage)
    {
        
        playerHealth -= collisionDamage;
        scoringSystem = GetComponent<Scoring>();
        scoringSystem.updateHealth();
        if (playerHealth <= 0)
        {

            PlayerDie();
        }
    }

    private void PlayerDie()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }



}
