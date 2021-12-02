using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeUI : MonoBehaviour
{
    [SerializeField]
    List<GameObject> lifes = new List<GameObject>();


    private void Awake()
    {
        InitializeSetting();
    }

    void InitializeSetting()
    {
        for (int i = 0; i < lifes.Count; i++)
        {
            lifes[i].SetActive(false);
        }
    }

    public void OnLifeUIUpdate()
    {
        int heartCount = GameManager.Instance.HeartCount;
        InitializeSetting();
        for (int i = 0; i < heartCount; i++)
        {
            lifes[i].SetActive(true);
        }
    }
}
