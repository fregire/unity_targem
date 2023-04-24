using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
    public int MaxHealth;
    public Slider HealthSlider;

    private float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MaxHealth;
        
        HealthSlider.maxValue = MaxHealth;
        HealthSlider.value = currentHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            gameObject.SetActive(false);
        }

        HealthSlider.value = currentHealth;
    }
}
