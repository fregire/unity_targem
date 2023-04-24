using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int MoveSpeed;   
    private Castle target;
    private Path path;
    private int currentPoint;

    private bool reachedEnd;

    private float attackCounter;
    public float timeBetweenAttacks, damagePerAttack;
    
    
    // Start is called before the first frame update
    void Start()
    {
        if (path == null)
        {
            path = FindObjectOfType<Path>();
        }
        if (target == null)
        {
            target = FindObjectOfType<Castle>();
        }        
        
        attackCounter = timeBetweenAttacks;
    }

    // Update is called once per frame
    void Update()
    {
        bool reachedEnd = currentPoint == path.Points.Length;
        
        if (!reachedEnd)
        {
            transform.LookAt(path.Points[currentPoint]);
            transform.position = Vector3.MoveTowards(transform.position, path.Points[currentPoint].position, MoveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, path.Points[currentPoint].position) < .01f)
                currentPoint += 1;
        }
        else
        {
            //transform.position = Vector3.MoveTowards(transform.position, theCastle.attackPoints[selectedAttackPoint].position, moveSpeed * Time.deltaTime);
            attackCounter -= Time.deltaTime;
            if(attackCounter <= 0)
            {
                attackCounter = timeBetweenAttacks;
                target.TakeDamage(damagePerAttack);
            }
        }
    }
    public void Setup(Castle newCastle, Path newPath)
    {
        target = newCastle;
        path = newPath;
    }
}
