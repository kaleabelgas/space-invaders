using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    public static playerController pcInstance;

    public Rigidbody2D playerRB;
    public Transform firepoint;
    public GameObject effectPrefab;

    public float moveSpeed;
    public float playerHealth = 100f;
    public float shakeDuration;
    public float shakeStrength;
    private Vector2 moveDirection;

    private void Start()
    {
        pcInstance = this;
    }

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
        Scoring.scoringInstance.updateHealth();
        cameraShake.instance.initializeShake(shakeStrength, shakeDuration);
        GameObject playerHitEffect = Instantiate(effectPrefab, transform.position, transform.rotation);
        if (playerHealth <= 0 )
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
