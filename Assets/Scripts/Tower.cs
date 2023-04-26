using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float Range = 3.0f;

    public Collider[] CollidersInRange;

    private List<EnemyController> enemiesInRange = new List<EnemyController>();

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
            
            enemiesInRange.Clear();
            foreach (Collider col in CollidersInRange)
            {
                enemiesInRange.Add(col.GetComponent<EnemyController>());
            }
        }
    }
}
