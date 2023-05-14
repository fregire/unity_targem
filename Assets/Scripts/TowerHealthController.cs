using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerHealthController : MonoBehaviour
{
    public int MaxHealth;
    public Slider HealthSlider;

    public float CurrentHealth;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
        
        HealthSlider.maxValue = MaxHealth;
        HealthSlider.value = CurrentHealth;
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            gameObject.SetActive(false);
        }

        HealthSlider.value = CurrentHealth;
    }
    
}
