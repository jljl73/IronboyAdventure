using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    TextMeshProUGUI scoreTextMesh;

    private void Awake()
    {
        scoreTextMesh = GetComponentInChildren<TextMeshProUGUI>();
        if (scoreTextMesh == null)
            throw new System.Exception("UIManager doesnt have TextMeshProUGUI");
    }

    void Start()
    {
        OnScoreUIUpdate();
    }

    public void OnScoreUIUpdate()
    {
        int score = GameManager.Instance.Score;
        string scoreText = "";

        for (int i = 1000000; i > 0; i /= 10)
        {
            if ((int)(score / i) == 0)
                scoreText += "0";
            else
            {
                scoreText += ((int)(score / i)).ToString();
                score %= i;
            }
        }

        scoreTextMesh.text = scoreText;
        print("Im in scoreUII");
    }
}
