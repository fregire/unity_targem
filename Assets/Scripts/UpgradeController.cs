using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeController : MonoBehaviour
{
    public Tower[] Towers;
    public GameObject BulletPrefab;

    public float UpgradeDamageAmount;
    public float UpgradeHealthAmount;
    public float UpgradeAttackSpeedAmount = 1;

    public float Price;
    public GameManager GameManager;
    public Button Button;

    public void Start()
    {
        Button.GetComponent<Button>().onClick.AddListener(Upgrade);
    }
    private void Upgrade()
    {
        if (GameManager.CurrentCoinsAmount < Price)
        {
            return;
        }

        GameManager.CurrentCoinsAmount -= Price;
        BulletPrefab.GetComponent<Bullet>().DamageAmount += UpgradeDamageAmount;
        BulletPrefab.GetComponent<Bullet>().MoveSpeed *= UpgradeAttackSpeedAmount;
        
        foreach (var tower in Towers)
        {
            var newHealthValue = tower.GetComponent<TowerHealthController>().CurrentHealth + UpgradeHealthAmount;
            if (newHealthValue >= tower.GetComponent<TowerHealthController>().MaxHealth)
            {
                tower.GetComponent<TowerHealthController>().CurrentHealth =
                    tower.GetComponent<TowerHealthController>().MaxHealth;
            }
            
        }
    }
}
