using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    public Transform playerTransform;
    public GameObject bulletPrefab;

    public float bulletForce;
    private GameObject bullet;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Shoot();
        }

    }

    

    private void Shoot()
    {
        bullet = Instantiate(bulletPrefab, playerTransform.position, playerTransform.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(playerTransform.up * bulletForce, ForceMode2D.Impulse);
    }
}
