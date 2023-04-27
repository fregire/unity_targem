using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject BulletPrefab;

    public Transform BulletSpawnPoint;

    public float TimeBetweenSpawn = 1.0f;

    private Transform target;
    private float shotCounter;

    public Tower CurrTower;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shotCounter -= Time.deltaTime;

        if (shotCounter <= 0 && target != null)
        {
            shotCounter = TimeBetweenSpawn;
            BulletSpawnPoint.LookAt(target);
            Instantiate(BulletPrefab, BulletSpawnPoint.position, BulletSpawnPoint.rotation);
        }

        if (CurrTower.EnemiesInRange.Count > 0)
        {
            float minDistance = CurrTower.Range + 1f;
            foreach (EnemyController enemy in CurrTower.EnemiesInRange)
            {
                if (enemy != null)
                {
                    float distance = Vector3.Distance(transform.position, enemy.transform.position);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        target = enemy.transform;
                    }
                }
            }
        }
        else
        {
            target = null;
        }
    }
}
