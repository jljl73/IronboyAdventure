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

    [SerializeField]
    GameObject GameOverPanel;

    private void Awake()
    {
        GameManager.Instance.uiManager = this;

        if (lifeUI == null)
            throw new System.Exception("UIManager doesnt have ScoreUI");

        if (scoreUI == null)
            throw new System.Exception("UIManager doesnt have ScoreUI");

        GameManager.Instance.AddGameOver(OnGameOver);
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
        print("Im in UIMANAGER OnScoreUIUpdate");
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

    public void OnGameOver()
    {
        GameOverPanel.SetActive(true);
    }

    public void GameRestart()
    {
        GameManager.Instance.GameRestart();
    }
}
