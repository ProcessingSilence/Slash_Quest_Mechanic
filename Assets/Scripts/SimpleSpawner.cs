using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class SimpleSpawner : MonoBehaviour
{
    public GameObject enemy;

    private Transform player;
    
    SimpleEnemy my_SimpleEnemy_script;

    public float spawnRateTimer;

    // Waits a delay when awake for first time.
    private bool amAwakened = true;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        StartCoroutine(SpawnTimer());
    }

    // Spawns enemies based on spawnRateTimer float.
    IEnumerator SpawnTimer()
    {
        if (amAwakened)
        {
            amAwakened = false;
            yield return new WaitForSecondsRealtime(spawnRateTimer);
            transform.position = new Vector3(transform.position.x, Random.Range(-7.5f, 7.5f), transform.position.z);
        }
        // Put "player" transform into enemy's target slot in SimpleEnemy.cs upon instantiation.
        var spawnedEnemy = Instantiate(enemy, transform.position, quaternion.identity);
        spawnedEnemy.GetComponent<SimpleEnemy>().target = player;
        yield return new WaitForSecondsRealtime(spawnRateTimer);
        transform.position = new Vector3(transform.position.x, Random.Range(-7.5f, 7.5f), transform.position.z);
        StartCoroutine(SpawnTimer());
    }
}
