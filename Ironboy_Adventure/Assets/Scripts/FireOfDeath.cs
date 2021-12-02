using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOfDeath : MonoBehaviour
{
    [SerializeField]
    int[] advancements;

    int index = 0;
    public float duration = 3.0f;
    void Start()
    {
        GameManager.Instance.AddAdvancementUpdate(BeginFire);
        EndFire();
    }

    void BeginFire()
    {
        if (GameManager.Instance.Advancement < advancements[index]) return;

        ++index;
        gameObject.SetActive(true);
        Invoke("EndFire", duration);
    }

    void EndFire()
    {
        gameObject.SetActive(false);
    }
}
