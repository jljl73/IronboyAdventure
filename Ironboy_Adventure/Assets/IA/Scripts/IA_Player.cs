using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_Player : MonoBehaviour
{
    const float immortalTime = 2.0f;
    const float hurtMotionTime = 1.0f;

    [SerializeField]
    int hearts = 3;
    public int Hearts { get => hearts; }

    float hurtTime = 0.0f;
    public float HurtTime {get => hurtTime;}

    bool dead = false;
    public bool Dead { get => dead; }

    Animator animator;
    #region Anim_Params
    bool Anim_Dead {
        get { return animator.GetBool("Dead"); }
        set { animator.SetBool("Dead", value); }
    }
    bool Anim_Hurt {
        get { return animator.GetBool("Hurt"); }
        set { animator.SetBool("Hurt", value); }
    }
    bool Anim_Running {
        get { return animator.GetBool("Running"); }
        set { animator.SetBool("Running", value); }
    }
    bool Anim_SpecialGuard {
        get { return animator.GetBool("Special Guard"); }
        set { animator.SetBool("Special Guard", value); }
    }
    bool Anim_Jump {
        //get { return animator.GetBool("Jump"); }
        set { animator.SetTrigger("Jump"); }
    }
    bool Anim_HorizontalAttack {
        //get { return animator.GetBool("Horizontal Attack"); }
        set { animator.SetTrigger("Horizontal Attack"); }
    }
    bool Anim_VerticalAttack {
        //get { return animator.GetBool("Vertical Attack"); }
        set { animator.SetTrigger("Vertical Attack"); }
    }
    bool Anim_Guard {
        get { return animator.GetBool("Guard"); }
        set { animator.SetBool("Guard", value); }
    }
    #endregion


    public void Damaged(int i)
    {
        if (i < 1 || hurtTime > 0.0f)
            return;

        hurtTime = immortalTime;
        hearts -= i;

        if (hearts <= 0)
        {
            hearts = 0;
            dead = true;
            Anim_Dead = true;
        }
    }

    public void Heal(int i)
    {
        hearts += i;
        if (i > 5)
            hearts = 5;
    }

    public void Revive()
    {
        dead = true;
        hearts = 3;
    }



    private void Awake()
    {
        animator = GetComponent<Animator>();   
    }

    private void Update()
    {
        if (hurtTime > 0.0f)
        {
            hurtTime -= Time.deltaTime;

            if (hurtTime > immortalTime - hurtMotionTime)
                Anim_Hurt = true;
            else
                Anim_Hurt = false;
        }
        else
            hurtTime = 0.0f;



        if (Input.GetKeyDown(KeyCode.Space))
            Anim_Jump = true;

        if (Input.GetKeyDown(KeyCode.Q))
            Anim_HorizontalAttack = true;

        if (Input.GetKeyDown(KeyCode.W))
            Anim_VerticalAttack = true;

        if (Input.GetKeyDown(KeyCode.E))
            Anim_Guard = true;
        else if (Input.GetKeyUp(KeyCode.E))
            Anim_Guard = false;

        if (Input.GetKeyDown(KeyCode.R))
            Anim_SpecialGuard = true;
        else if (Input.GetKeyUp(KeyCode.R))
            Anim_SpecialGuard = false;

        if (Input.GetKeyDown(KeyCode.Z))
            Anim_Hurt = !Anim_Hurt;
        if (Input.GetKeyDown(KeyCode.X))
            Anim_Dead = !Anim_Dead;
        if (Input.GetKeyDown(KeyCode.UpArrow))
            Anim_Running = !Anim_Running;

        
    }
}
