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

    public GameObject spawnMarker;

    private bool canSpawnAgain;
    void Start()
    {
        spawnMarker.SetActive(false);
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        StartCoroutine(SpawnTimer());
    }

    // Spawns enemies based on spawnRateTimer float.
    IEnumerator SpawnTimer()
    {
        // Waits a delay when awake for first time.
        if (amAwakened)
        {
            amAwakened = false;
            canSpawnAgain = false;
            StartCoroutine(MarkerTime());
            while (canSpawnAgain == false)
            {
                yield return null;
            }
            transform.position = spawnMarker.transform.position;
        }
        // Put "player" transform into enemy's target slot in SimpleEnemy.cs upon instantiation.
        var spawnedEnemy = Instantiate(enemy, transform.position, quaternion.identity);
        spawnedEnemy.GetComponent<SimpleEnemy>().target = player;
        canSpawnAgain = false;
        StartCoroutine(MarkerTime());      
        while (canSpawnAgain == false)
        {
            yield return null;
        }
        
        StartCoroutine(SpawnTimer());
    }

    IEnumerator MarkerTime()
    {
        yield return new WaitForSecondsRealtime(spawnRateTimer/2);
        spawnMarker.transform.position = new Vector3(Random.Range(-8.5f, 8.5f), Random.Range(-7.5f, 7.5f), transform.position.z);
        spawnMarker.SetActive(true);
        yield return new WaitForSecondsRealtime(spawnRateTimer/2);
        spawnMarker.SetActive(false);
        transform.position = spawnMarker.transform.position;
        canSpawnAgain = true;
    }
}
