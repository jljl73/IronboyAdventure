using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueDokev : Dokev
{
    [SerializeField]
    IA_PlayerSkillTrigger.SkillType type = IA_PlayerSkillTrigger.SkillType.HorizontalAttack;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerAttack"))
        {
            if (other.GetComponent<IA_PlayerSkillTrigger>().TriggerType == type)
                Hit();
        }
        else if (other.CompareTag("AttackTrigger"))
            Attack();
        else if (other.CompareTag("FireOfDeath"))
            Die();
        else if (other.CompareTag("Alert"))
            StartCoroutine(Blink());
    }
}
