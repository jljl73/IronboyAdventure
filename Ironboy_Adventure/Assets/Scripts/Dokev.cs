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
        Destroy(gameObject, 20.0f);
    }

    protected void Hit()
    {
        GameManager.Instance.Score += 100;
        GameManager.Instance.Combo += 1;
        GetComponent<AudioSource>().Play();
        Die();
    }

    protected void Die()
    {
        animator.SetTrigger("Die");
        GetComponent<Mover>().Move(false);
        GetComponent<Collider>().enabled = false;
        Destroy(gameObject, 2.0f);
    }

    protected void Attack()
    {
        //GetComponent<Mover>().Move(false);
        animator.SetTrigger("Attack 02");
        Destroy(gameObject, 4.0f);
    }

}
