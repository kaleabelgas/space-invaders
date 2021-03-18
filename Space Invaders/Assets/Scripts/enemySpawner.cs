using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{

    public static enemySpawner enemySpawnerInstance;

    public Transform[] spawnPoints;
    public GameObject enemy;
    public float timer = 1;
    private float reduceTimer = 0;
    private float timeBeforeSpeedup = 1;
    private bool isCoroutineExecuting = false;

    public int defaultEnemyHealth = 100;
    // Start is called before the first frame update
    void Start()
    {
        enemySpawnerInstance = this;
    }

    // Update is called once per frame
    void Update()
    {
        reduceTimer += Time.deltaTime;
        if (reduceTimer >= timeBeforeSpeedup && timer > 0.2f)
        {
            timer -= 0.01f;
            reduceTimer = 0;
            defaultEnemyHealth += 4;
        }
        StartCoroutine(Spawner(timer));

    }


    private IEnumerator Spawner(float currentTImer)
    {
        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;
        yield return new WaitForSeconds(currentTImer);

        int randSpawnPoint = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy, spawnPoints[randSpawnPoint].position, transform.rotation);


        isCoroutineExecuting = false;
    }

}
