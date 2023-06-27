using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PriceDisplay : MonoBehaviour
{
    [SerializeField] private SkillButton _skillButton;
    [SerializeField] private TMP_Text _text;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();

        if (_skillButton.IsPaid == false)
        {
            _image.color = Color.clear;
            _text.color = Color.clear;
            enabled = false;
        }
        else
        {
            _text.text = Convert.ToString(_skillButton.Price);
        }
    }
}