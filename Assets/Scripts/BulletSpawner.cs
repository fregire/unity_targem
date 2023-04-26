using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject BulletPrefab;

    public Transform BulletSpawnPoint;

    public float TimeBetweenSpawn = 1.0f;

    private float shotCounter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shotCounter -= Time.deltaTime;

        if (shotCounter <= 0)
        {
            shotCounter = TimeBetweenSpawn;

            Instantiate(BulletPrefab, BulletSpawnPoint.position, BulletSpawnPoint.rotation);
        }
    }
}
