using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float duration = 4.0f;
    [SerializeField]
    int type = 0;

    public bool Reflectable;

    void Start()
    {
        Destroy(gameObject, duration);
    }

    public void ChangeDirectionReverse()
    {
        if (Reflectable)
            GetComponent<Mover>().MulSpeed(-1.0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerAttack"))
        {
            if (!Reflectable)
                Destroy(gameObject);
            else
                ChangeDirectionReverse();
        }
        else if (other.CompareTag("Boss"))
            Destroy(gameObject);
        else if (other.CompareTag("FireOfDeath"))
            Destroy(gameObject);
    }
}
