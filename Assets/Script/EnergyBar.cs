using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{

    public Slider slider;


    private void Start()
    {
        slider.maxValue = 100;
        slider.value = PlayerAction.Instance.GetEnergy();
    }


    private void Update()
    {
        SetEnergy();
    }

    public void SetEnergy()
    {
        slider.value = PlayerAction.Instance.GetEnergy();
    }

}
