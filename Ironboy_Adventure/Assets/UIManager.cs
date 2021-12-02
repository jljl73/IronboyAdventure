using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    LifeUI lifeUI;
    public RectTransform GetLifeUITransform() { return lifeUI.GetComponent<RectTransform>(); }

    [SerializeField]
    HeartAquisitionMotion hearAquisition;

    [SerializeField]
    ScoreUI scoreUI;

    [SerializeField]
    AdvancementUI advancementUI;

    [SerializeField]
    ComboUI comboUI;

    private void Awake()
    {
        GameManager.Instance.uiManager = this;

        if (lifeUI == null)
            throw new System.Exception("UIManager doesnt have ScoreUI");

        if (scoreUI == null)
            throw new System.Exception("UIManager doesnt have ScoreUI");
    }
    public void OnLifeUIUpdate()
    {
        lifeUI.OnLifeUIUpdate();
    }
    public void OnTriggerHeartAquisition()
    {
        hearAquisition.Activate();
    }

    public void OnScoreUIUpdate()
    {
        scoreUI.OnScoreUIUpdate();
    }

    public void OnAdvancementUpdate()
    {
        advancementUI.OnAdvancementUpdate();
    }

    public void OnComboUpdate()
    {
        comboUI.OnComboUIUpdate();
    }
}
