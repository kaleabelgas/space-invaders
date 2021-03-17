using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooter : MonoBehaviour
{

    public Transform playerTransform;
    public GameObject bulletPrefab;
    public Text textScore;

    public float bulletForce;
    public float attackSpeed = 0.1f;
    private GameObject bullet;
    private bool isShootingBullet = false;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            StartCoroutine(Shoot(attackSpeed));
        }

    }

    

    private IEnumerator Shoot(float bulletTimer)
    {
        if (isShootingBullet)
            yield break;
        isShootingBullet = true;
        yield return new WaitForSeconds(bulletTimer);

        if (Scoring.scoringInstance.score > 0)
        {
            Scoring.scoringInstance.score--;
            textScore.text = "Score: " + Scoring.scoringInstance.score.ToString();
            bullet = Instantiate(bulletPrefab, playerTransform.position, playerTransform.rotation);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.AddForce(playerTransform.up * bulletForce, ForceMode2D.Impulse);



        }
        isShootingBullet = false;

        
    }
}
