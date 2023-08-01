using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    private static CoinUI _instance;
    public static CoinUI Instance
    {
        get
        {
            if( _instance == null)
            {
                _instance = GameObject.Find("CoinUI").GetComponent<CoinUI>();
            }
            return _instance;
        }
    }

    private TMP_Text text;
    public static float currentCoinAmount;


    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<TMP_Text>();
        currentCoinAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoinAmount(float amount = 1)
    {
        currentCoinAmount+=amount;
        text.text = currentCoinAmount.ToString();
    }

    public void ReduceCoinAmount(float amount = 1)
    {
        currentCoinAmount -= amount;
        text.text = currentCoinAmount.ToString();
    }

}
