using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealthController : MonoBehaviour
{
    public float TotalHealth;

    public Slider HealthBar;
    // Start is called before the first frame update
    void Start()
    {
        HealthBar.maxValue = TotalHealth;
        HealthBar.value = TotalHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damageAmount)
    {
        TotalHealth -= damageAmount;
        if (TotalHealth <= 0)
        {
            TotalHealth = 0;
            Destroy(gameObject);
        }

        HealthBar.value = TotalHealth;
    }
}
