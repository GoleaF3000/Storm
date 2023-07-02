using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerWallet : MonoBehaviour
{
    [SerializeField] private int _countCoins;

    public event UnityAction<int> AddedReward;

    public int CountCoins => _countCoins;

    private void Start()
    {
        AddedReward?.Invoke(_countCoins);
    }

    public void PutReward(int reward)
    {
        _countCoins += reward;
        AddedReward?.Invoke(_countCoins);
    }

    public void PayCoins(int price)
    {
        _countCoins -= price;
        AddedReward?.Invoke(_countCoins);
    }
}