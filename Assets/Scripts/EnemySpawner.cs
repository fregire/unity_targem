using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemySpawner : MonoBehaviour
{
    public EnemyController enemyToSpawn;

    public Transform spawnPoint;

    public float timeBetweenSpawns;
    private float spawnCounter;

    public int amountToSpawn = 15;

    [FormerlySerializedAs("theCastle")] public TowerHealthController theTowerHealthController;
    public Path thePath;

    void Start()
    {
        spawnCounter = timeBetweenSpawns;
    }

    void Update()
    {
        if (amountToSpawn > 0)
        {
            spawnCounter -= Time.deltaTime;
            if (spawnCounter <= 0)
            {
                spawnCounter = timeBetweenSpawns;

                Instantiate(enemyToSpawn, spawnPoint.position, spawnPoint.rotation);
                amountToSpawn --;
            }
        }


    }
}
