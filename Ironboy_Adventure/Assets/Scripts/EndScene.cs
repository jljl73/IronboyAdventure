using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Restart", 20.0f);

    }

    public void Restart()
    {
        GameManager.Instance.ChangeScene("Main");
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
}
