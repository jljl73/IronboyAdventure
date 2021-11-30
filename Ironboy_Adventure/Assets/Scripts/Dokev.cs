using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dokev : MonoBehaviour
{
    protected Animator animator;

    protected void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Run Forward", true);
    }

    protected void Hit()
    {
        GetComponent<Mover>().Move(false);
        animator.SetTrigger("Die");
        Destroy(gameObject, 2.0f);
    }
}