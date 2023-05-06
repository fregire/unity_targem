using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int MoveSpeed;   
    private Tower target;
    private Path path;
    private int currentPoint;
    public float AttackRange;

    private bool reachedEnd;

    private float attackCounter;
    public float timeBetweenAttacks, damagePerAttack;


    private Tower findClosestTarget()
    {
        Tower[] targets = FindObjectsByType<Tower>(FindObjectsSortMode.None);
        Tower chosenTarget = targets[0];
        float minDistance = Vector3.Distance(transform.position, chosenTarget.transform.position);

        for (var i = 1; i < targets.Length; i++)
        {
            var distance = Vector3.Distance(transform.position, targets[i].transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                chosenTarget = targets[i];
            }
        }

        return chosenTarget;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (path == null)
        {
            path = FindObjectOfType<Path>();
        }
        if (target == null)
        {
            target = findClosestTarget();
        }        
        
        attackCounter = timeBetweenAttacks;
    }

    // Update is called once per frame
    void Update()
    {
        bool reachedPathEnd = currentPoint == path.Points.Length;
        
        if (!reachedPathEnd)
        {
            transform.LookAt(path.Points[currentPoint]);
            transform.position = Vector3.MoveTowards(transform.position, path.Points[currentPoint].position, MoveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, path.Points[currentPoint].position) < .01f)
                currentPoint += 1;
            
            return;   
        }
        
        target = findClosestTarget();
        bool reachedTargetEnd = Vector3.Distance(transform.position, target.transform.position) <= AttackRange;
        if (!reachedTargetEnd)
        {
            transform.LookAt(target.transform);
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, MoveSpeed * Time.deltaTime);
            return;
        }
        
        attackCounter -= Time.deltaTime;
        if(attackCounter <= 0)
        {
            attackCounter = timeBetweenAttacks;
            target.GetComponent<TowerHealthController>().TakeDamage(damagePerAttack);
        }
    }
    /* public void Setup(TowerHealthController newTowerHealthController, Path newPath)
    {
        target = newTowerHealthController;
        path = newPath;
    } */
}
