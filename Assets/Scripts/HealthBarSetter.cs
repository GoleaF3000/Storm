using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Slider))]
public abstract class HealthBarSetter : MonoBehaviour
{    
    [SerializeField] protected Canvas _canvas;
    [SerializeField] protected Vector3 _ofset;    
   
    protected Slider _slider;    

    protected void Awake()
    {
        _slider = GetComponent<Slider>();        
    }  

    protected void SetMaxValue(int maxValue)
    {       
        _slider.maxValue = maxValue;
        _slider.value = maxValue;
        _canvas.enabled = false;
    }

    protected void ChangeValue(int value)
    {       
        _canvas.enabled = true;
        _slider.value = value;
    }    
}