using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public float distance = 2.0f;
    [SerializeField]
    GameObject[] fires;
    [SerializeField]
    Transform GunPoint;

    Animator animator;
    public GameObject player;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(AttackFirst());
    }

    void AttackProjectile()
    {
        animator.SetTrigger("Projectile Attack Front");
    }

    void CreateProjectileEvent()
    {
        GameObject projectile = Instantiate(fires[Random.Range(0, fires.Length)],
            GunPoint.position, transform.rotation);
        projectile.GetComponent<Mover>().SetTarget(player);
    }

    IEnumerator AttackFirst()
    {
        int count = 0;
        while(count++ < 5)
        {
            AttackProjectile();
            yield return new WaitForSeconds(3.0f);
        }
        StartCoroutine(AttackSecond());
    }

    IEnumerator AttackSecond()
    {
        int count = 0;
        while (count++ < 5)
        {
            AttackProjectile();
            yield return new WaitForSeconds(3.0f);
        }
        StartCoroutine(AttackThird());
    }

    IEnumerator AttackThird()
    {
        int count = 0;
        while (count++ < 7)
        {
            AttackProjectile();
            yield return new WaitForSeconds(3.0f);
        }
        StartCoroutine(AttackFirst());
    }
}
