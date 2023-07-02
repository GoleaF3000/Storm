using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsDisplay : MonoBehaviour
{
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private TMP_Text _coinsDisplay;

    private void OnEnable()
    {
        _wallet.AddedReward += ChangeCoins;
    }

    private void OnDisable()
    {
        _wallet.AddedReward -= ChangeCoins;
    }

    private void ChangeCoins(int reward)
    {
        _coinsDisplay.text = reward.ToString();
    }
}
