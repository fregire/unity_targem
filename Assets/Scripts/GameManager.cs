using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Tower[] Towers;
    public float RewardPerEnemy;
    public float CurrentCoinsAmount;

    private bool towersDestroyed;

    public Transform LostPopup;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (towersDestroyed && !LostPopup.gameObject.activeSelf)
        {   
            LostPopup.gameObject.SetActive(true);
        }
        else
        {
            if (Towers.All((tower) => !tower.isActiveAndEnabled))
            {
                towersDestroyed = true;
            }   
        }
    }

    public void HandleDestroyedEnemy(EnemyController enemy)
    {
        CurrentCoinsAmount += RewardPerEnemy;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
