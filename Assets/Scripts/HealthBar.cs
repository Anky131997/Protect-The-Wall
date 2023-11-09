using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }
    public void DeductHealth(int health)
    {
        slider.value -= health;
        if (slider.value == 0)
        {
            GameManager.instance.GameOver();
        }
    }

    public void IncreaseHealth(int health)
    {
        slider.value += health;
    }

}
