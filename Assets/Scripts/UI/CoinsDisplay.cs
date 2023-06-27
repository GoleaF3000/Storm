using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsDisplay : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _coinsDisplay;

    private void OnEnable()
    {
        _player.AddedReward += ChangeCoins;
    }

    private void OnDisable()
    {
        _player.AddedReward -= ChangeCoins;
    }

    private void ChangeCoins(int reward)
    {
        _coinsDisplay.text = reward.ToString();
    }
}
