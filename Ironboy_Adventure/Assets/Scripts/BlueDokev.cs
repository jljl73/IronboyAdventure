using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueDokev : Dokev
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerAttack"))
            Hit();
    }
}
