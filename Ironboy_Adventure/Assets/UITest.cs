using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITest : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            GameManager.Instance.HeartCount = GameManager.Instance.HeartCount + 1;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            GameManager.Instance.Score = GameManager.Instance.Score + 11;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            GameManager.Instance.Combo = GameManager.Instance.Combo + 10;
        }

        if (Input.GetKeyDown(KeyCode.A))

        {
            GameManager.Instance.Advancement = GameManager.Instance.Advancement + 1;
        }
    }
}
