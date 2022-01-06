using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fires : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FireOfDeath"))
            Destroy(gameObject);
    }
}
