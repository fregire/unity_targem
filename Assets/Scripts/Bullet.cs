using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody BulletPrefab;

    public float MoveSpeed;

    public float DamageAmount;
    // Start is called before the first frame update
    void Start()
    {
        BulletPrefab.velocity = transform.forward * MoveSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealthController>().TakeDamage(DamageAmount);
        }
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
