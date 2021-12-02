using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float duration = 4.0f;
    [SerializeField]
    IA_PlayerSkillTrigger.SkillType type;

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
            if (other.GetComponent<IA_PlayerSkillTrigger>().TriggerType == type)
                Hit();
        }
        else if (other.CompareTag("Boss"))
            Destroy(gameObject);
        else if (other.CompareTag("FireOfDeath"))
            Destroy(gameObject);
    }

    void Hit()
    {
        if (!Reflectable)
            Destroy(gameObject);
        else
            ChangeDirectionReverse();
    }
}
