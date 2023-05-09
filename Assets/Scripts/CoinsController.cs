using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsController : MonoBehaviour
{
    public GameManager GameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = GameManager.CurrentCoinsAmount.ToString();
    }
}
