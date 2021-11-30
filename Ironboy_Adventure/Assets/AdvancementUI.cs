using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AdvancementUI : MonoBehaviour
{
    Slider slider;
    TextMeshProUGUI advancementText;

    void Awake()
    {
        slider = GetComponent<Slider>();
        advancementText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void OnAdvancementUpdate()
    {
        slider.value = GameManager.Instance.Advancement;
        advancementText.text = slider.value.ToString() + " / " + slider.maxValue.ToString();
    }
}
