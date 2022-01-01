using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOfDeath : MonoBehaviour
{
    [SerializeField]
    int[] advancements;
    [SerializeField]
    GameObject Fire;
    [SerializeField]
    GameObject Alert;


    int index = 0;
    public float duration = 3.0f;
    void Start()
    {
        GameManager.Instance.AddAdvancementUpdate(PrepareFire);
    }

    void PrepareFire()
    {
        if (GameManager.Instance.Advancement < advancements[index]) return;

        ++index;
        GetComponent<AudioSource>().Play();
        StartCoroutine(Blink());
        Invoke("BeginFire", 3.0f);
    }

    void BeginFire()
    {
        Fire.SetActive(true);
        Invoke("EndFire", duration);
    }

    void EndFire()
    {
        Fire.SetActive(false);
        Alert.SetActive(false);
    }

    IEnumerator Blink()
    {
        for(int i = 0; i < 6; ++i)
        {
            Alert.SetActive(!Alert.activeSelf);
            yield return new WaitForSeconds(duration/6);
        }
    }
}
