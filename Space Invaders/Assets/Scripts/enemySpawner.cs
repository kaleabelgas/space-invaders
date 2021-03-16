using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject enemy;
    public float timer = 1;
    private bool isCoroutineExecuting = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
