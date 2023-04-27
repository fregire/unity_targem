using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Tower : MonoBehaviour
{
    public float Range = 3.0f;

    public Collider[] CollidersInRange;

    public List<EnemyController> EnemiesInRange = new List<EnemyController>();

    private float checkCounter;

    public float CheckTime = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        checkCounter = CheckTime;
    }

    // Update is called once per frame
    void Update()
    {
        checkCounter -= Time.deltaTime;
        if (checkCounter <= 0)
        {
            checkCounter = CheckTime;
            CollidersInRange = Physics.OverlapSphere(transform.position, Range);
            
            EnemiesInRange.Clear();
            foreach (Collider col in CollidersInRange)
            {
                EnemiesInRange.Add(col.GetComponent<EnemyController>());
            }
        }
    }
}
