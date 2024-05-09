using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;
    public SOInt coins;
    public SOInt miniBalls;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        
    }

    private void Start()
    {
        Reset();
    }
    private void Reset()
    {
        coins.value = 0;
        miniBalls.value = 0;
    }

    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
        
    }

    public void AddMiniBall(int amount = 1)
    {
        miniBalls.value += amount;
    }

}
