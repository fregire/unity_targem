using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody BulletPrefab;

    public float MoveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        BulletPrefab.velocity = transform.forward * MoveSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
