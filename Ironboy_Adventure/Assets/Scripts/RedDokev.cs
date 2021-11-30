using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDokev : Dokev
{
    void Attack()
    {
        animator.SetTrigger("Attack 01");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerAttack"))
            Hit();

        else if (other.CompareTag("Player"))
            Attack();

    }
}
