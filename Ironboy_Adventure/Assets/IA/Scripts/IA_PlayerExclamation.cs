using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IA_PlayerExclamation : MonoBehaviour
{
    [SerializeField]
    Collider trigger;
    [SerializeField]
    Image bubble;
    [SerializeField]
    List<Collider> ignoreList;


    [SerializeField]
    float disappearTime = 0.5f;

    float timer;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        bubble.gameObject.SetActive(false);
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
            bubble.gameObject.SetActive(false);
        else
        {
            timer -= Time.deltaTime;

            bubble.transform.LookAt(
                bubble.transform.position + cam.transform.rotation * Vector3.forward,
                cam.transform.rotation * Vector3.up);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((ignoreList != null && ignoreList.Contains(other)) || other.CompareTag("Enemy"))
            return;

        bubble.gameObject.SetActive(true);
        timer = disappearTime;
    }
}
