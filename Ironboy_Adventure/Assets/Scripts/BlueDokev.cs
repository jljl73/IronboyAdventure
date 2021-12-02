using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueDokev : Dokev
{
    [SerializeField]
    IA_PlayerSkillTrigger.SkillType type = IA_PlayerSkillTrigger.SkillType.VerticalAttack;

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
            Hit();
    }
}
