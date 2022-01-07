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
    [SerializeField]
    int[] nAttack;
    [SerializeField]
    float[] Speed;

    int state = 0;
    Animator animator;
    public GameObject player;
    bool Reflectable = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(AttackFirst());
    }




    void BeginAttackAnimation()
    {
        animator.SetTrigger("Projectile Attack Front");
    }

    void CreateProjectileEvent()
    {
        GameObject projectile = Instantiate(fires[Random.Range(0, fires.Length)],
            GunPoint.position, transform.rotation);
        projectile.GetComponent<Mover>().SetTarget(player);
        projectile.GetComponent<Mover>().MulSpeed(Speed[state]);
        projectile.GetComponent<Fire>().Reflectable = Reflectable;
    }

    IEnumerator AttackFirst()
    {
        int count = 0;
        while (state == 0)
        {
            count++;
            Reflectable = (count == nAttack[0]) ? true : false;
            BeginAttackAnimation();
            yield return new WaitForSeconds(4.0f);

            if (Reflectable) count = 0;
        }

        StartCoroutine(AttackSecond());
    }

    IEnumerator AttackSecond()
    {
        int count = 0;
        while (state == 1)
        {
            count++;
            Reflectable = (count == nAttack[1]) ? true : false;
            BeginAttackAnimation();
            yield return new WaitForSeconds(4.0f);
            if (Reflectable) count = 0;
        }
        StartCoroutine(AttackThird());
    }

    IEnumerator AttackThird()
    {
        int count = 0;
        while (state == 2)
        {
            count++;
            Reflectable = (count == nAttack[2]) ? true : false;
            BeginAttackAnimation();
            yield return new WaitForSeconds(4.0f);
            if (Reflectable) count = 0;
        }
    }

    void Die()
    {
        animator.SetTrigger("Die");
        Invoke("EndGame", 2f);
    }

    void EndGame()
    {
        GameManager.Instance.ChangeScene("End");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            ++state;
            GetComponent<AudioSource>().Play();
            if(state < 3) animator.SetTrigger("Take Damage");
            else Die();
        }
    }
}
