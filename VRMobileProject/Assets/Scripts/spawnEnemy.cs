using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour
{

    private float spawnRadius = 85.0f;
    [SerializeField] float spawnTime = 5.0f;
    [SerializeField] GameObject enemyPrefab;
    List<float> unusedSpawnDirections = new List<float>();
    // Start is called before the first frame update
    void Start()
    {
        for(float i = 0.0f; i< 360.0f; i+=3)
        {
            unusedSpawnDirections.Add(i);
        }
        InvokeRepeating("Spawn", 0.0f, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnAllAtOnce()
    {
        for (int i = 0; i < 360; i+=3)
        {
            float distanceX = spawnRadius * Mathf.Cos(i);
            float distanceZ = spawnRadius * Mathf.Sin(i);
            Vector3 placement = new Vector3(distanceX, 0.0f, distanceZ);
            Instantiate(enemyPrefab, placement, Quaternion.identity);
        }
    }
    void Spawn()
    {
        if (unusedSpawnDirections.Count <= 0) return;
        int direction = Random.Range(0, unusedSpawnDirections.Count);
        float distanceX = spawnRadius * Mathf.Cos(unusedSpawnDirections[direction]);
        float distanceZ = spawnRadius * Mathf.Sin(unusedSpawnDirections[direction]);
        Vector3 placement = new Vector3( distanceX, 0.0f, distanceZ );
        Debug.Log("I was spawned at {" + placement.ToString() + " } with a direction of "+ unusedSpawnDirections[direction]);
        Instantiate(enemyPrefab, placement, Quaternion.identity);
        unusedSpawnDirections.RemoveAt(direction);
    }
}
