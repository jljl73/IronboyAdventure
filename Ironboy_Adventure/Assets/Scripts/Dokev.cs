using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dokev : MonoBehaviour
{
    protected Animator animator;
    protected SkinnedMeshRenderer meshRenderer;

    protected void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Run Forward", true);
        meshRenderer = transform.GetComponentInChildren<SkinnedMeshRenderer>();
        Destroy(gameObject, 20.0f);
    }
    
    protected IEnumerator Blink()
    {
        while (true)
        {
            meshRenderer.materials[0].color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
            yield return new WaitForSeconds(0.2f);
            meshRenderer.materials[0].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            yield return new WaitForSeconds(0.2f);
        }
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
        GetComponent<Mover>().MulSpeed(0.4f);
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
