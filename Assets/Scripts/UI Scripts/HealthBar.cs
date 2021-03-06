using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Image fillImage;
    private Slider slider;
    private float fillValue;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        if (slider.value <= slider.minValue)
            fillImage.enabled = false;
        if (slider.value > slider.minValue && fillImage.enabled)
            fillImage.enabled = true;

        fillValue = playerHealth.currentHealth / playerHealth.maxHealth;

        if (fillValue <= slider.maxValue / 3)
            fillImage.color = Color.red;
        else if (fillValue > slider.maxValue / 3)
            fillImage.color = Color.white;

        slider.value = fillValue;
    }
}
