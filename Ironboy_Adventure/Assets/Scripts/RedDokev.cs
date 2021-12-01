using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDokev : Dokev
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerAttack"))
            Hit();
        else if (other.CompareTag("Player"))
            Attack();
        else if (other.CompareTag("FireOfDeath"))
            Hit();
    }
}
