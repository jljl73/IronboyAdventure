using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject boss;
    [SerializeField]
    GameObject progress;

    [SerializeField]
    Vector3 CameraRotation;
    bool Spawn = false;

    float advancement
    {
        get => GameManager.Instance.Advancement;
    }

    void Start()
    {
        GameManager.Instance.AddAdvancementUpdate(SpawnBoss);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
            GameManager.Instance.Advancement = 95.0f;
    }

    void SpawnBoss()
    {
        if (Spawn)
            GameManager.Instance.RemoveAdvancementUpdate(SpawnBoss);

        if (advancement >= 100)
        {
            boss.SetActive(true);
            GameManager.Instance.BossMode = true;
            Spawn = true;
            Camera.main.transform.rotation = Quaternion.Euler(CameraRotation);
            Camera.main.transform.Translate(Vector3.back);
            progress.SetActive(false);
        }
    }

}
