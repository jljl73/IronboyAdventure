using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_PlayerSkillTrigger : MonoBehaviour
{
    public enum SkillType
    {
        Guard,
        SpecialGuard,
        VerticalAttack,
        HorizontalAttack
    }

    [SerializeField]
    SkillType triggerType;
    public SkillType TriggerType {get => triggerType;}


}
