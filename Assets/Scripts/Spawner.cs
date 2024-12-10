using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstaclesPrefab;
    public float timeBetweenSpawns;
    private float spawnTime;

    public float maxX, maxY, minX, minY;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTime)
        {
            SpawnObstacles();
            spawnTime = Time.time + timeBetweenSpawns;

        }
    }

    void SpawnObstacles()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Instantiate(obstaclesPrefab, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
