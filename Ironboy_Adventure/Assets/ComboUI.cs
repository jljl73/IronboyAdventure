using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComboUI : MonoBehaviour
{
    private void Awake()
    {
        InitializeSetting();
    }

    void InitializeSetting()
    {
        GetComponent<TextMeshProUGUI>().text = "";
    }

    public void OnComboUIUpdate()
    {
        int Combo = GameManager.Instance.Combo;
        if (Combo == 0)
            InitializeSetting();
        else if(Combo % 15 == 0)
            GetComponent<TextMeshProUGUI>().text = "<color=#590000>" + Combo.ToString() + " Combo</color>";
        else
            GetComponent<TextMeshProUGUI>().text = Combo.ToString() + " Combo";
    }
}
