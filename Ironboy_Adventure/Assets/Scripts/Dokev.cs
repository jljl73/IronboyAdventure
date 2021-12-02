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
        GetComponent<Collider>().enabled = false;
        GameManager.Instance.Score += 100;
        Destroy(gameObject, 2.0f);
    }

    protected void Attack()
    {
        //GetComponent<Mover>().Move(false);
        animator.SetTrigger("Attack 02");
        Destroy(gameObject, 3.0f);
    }

}
