using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_Player : MonoBehaviour
{
    const float immortalTime = 2.0f;
    const float hurtMotionTime = 1.0f;
    [SerializeField]
    float moveGap = 1.0f;

    [SerializeField]
    Collider collider_PlayerBody;
    public Collider Collider_PlayerBody
    { get => collider_PlayerBody; }

    [SerializeField]
    Collider collider_VerticalAttack;
    public Collider Collider_VerticalAttack
    { get => collider_VerticalAttack; }

    [SerializeField]
    Collider collider_HorizontalAttack;
    public Collider Collider_HorizontalAttack
    { get => collider_HorizontalAttack; }

    [SerializeField]
    Collider collider_Guard;
    public Collider Collider_Guard
    { get => collider_Guard; }

    [SerializeField]
    Collider collider_SpecialGuard;
    public Collider Collider_SpecialGuard
    { get => collider_SpecialGuard; }

    [SerializeField]
    AudioClip VerticalAttack;
    [SerializeField]
    AudioClip HorizontalAttack;
    [SerializeField]
    AudioClip Hit;

    [SerializeField]
    public int Hearts
    {
        get => GameManager.Instance.HeartCount;
        set => GameManager.Instance.HeartCount = value;
    }

    float hurtTime = 0.0f;
    public float HurtTime {get => hurtTime;}

    float jumpTime = 0.0f;
    public float JumpTime {get => jumpTime;}

    bool dead = false;
    public bool Dead { get => dead; }

    bool GameOver
    {
        get => GameManager.Instance.GameOver;
        set => GameManager.Instance.GameOver = value;
    }

    Vector3 startPos;
    int currentRail = 0;


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
        get { return animator.GetBool("Jump"); }
        set { animator.SetBool("Jump", value); }
    }
    bool Anim_HorizontalAttack {
        get { return animator.GetBool("Horizontal Attack"); }
        set { animator.SetBool("Horizontal Attack", value); }
    }
    bool Anim_VerticalAttack {
        get { return animator.GetBool("Vertical Attack"); }
        set { animator.SetBool("Vertical Attack", value); }
    }
    bool Anim_Guard {
        get { return animator.GetBool("Guard"); }
        set { animator.SetBool("Guard", value); }
    }
    //bool Anim_RunRight {
    //    //get { return animator.GetBool("Run Right"); }
    //    set { animator.SetTrigger("Run Right"); }
    //}
    //bool Anim_RunLeft {
    //    //get { return animator.GetBool("Run Left"); }
    //    set { animator.SetTrigger("Run Left"); }
    //}
    #endregion

    public void PlaySound(string value)
    {
        switch (value)
        {
            case "Vertical":
                GetComponent<AudioSource>().clip = VerticalAttack;
                break;
            case "Horizontal":
                GetComponent<AudioSource>().clip = HorizontalAttack;
                break;
            case "Hit":
                GetComponent<AudioSource>().clip = Hit;
                break;
        }

        GetComponent<AudioSource>().Play();
    }


    public bool Damaged(int i)
    {
        if (i < 1 || hurtTime > 0.0f)
            return false;

        hurtTime = immortalTime;
        Hearts -= i;
        GameManager.Instance.Combo = 0;
        PlaySound("Hit");
        if (Hearts <= 0)
        {
            Hearts = 0;
            dead = true;
            Anim_Dead = true;
            GameOver = true;
        }

        return true;
    }

    public bool TryJump()
    {
        if (jumpTime > 0.0f)
            return false;

        jumpTime = 1.0f;
        return true;
    }

    public void Revive()
    {
        dead = true;
        Hearts = 3;
        GameOver = false;
    }

    public bool MoveRight()
    {
        if (currentRail >= 1)
            return false;

        currentRail++;
        transform.Translate(new Vector3(moveGap, 0, 0));
        return true;
    }
    public bool MoveLeft()
    {
        if (currentRail <= -1)
            return false;

        currentRail--;
        transform.Translate(new Vector3(-moveGap, 0, 0));
        return true;
    }


    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        animator.GetBehaviour<IA_PlayerSB_Base>().player = this;
        animator.GetBehaviour<IA_PlayerSB_UpperBody>().player = this;

        startPos = transform.position;
        Anim_Running = true;
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

        if (jumpTime > 0.0f)
            jumpTime -= Time.deltaTime;
        else
            jumpTime = 0.0f;

        if(!GameOver)
            GameManager.Instance.Advancement += Time.deltaTime;

        if (GameManager.Instance.BossMode)
            transform.position = Vector3.zero;



        if (Input.GetKeyDown(KeyCode.Space) && TryJump())
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
        {
            Anim_SpecialGuard = true;
            GetComponent<Collider>().enabled = false;
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            Anim_SpecialGuard = false;
            GetComponent<Collider>().enabled = true;
        }


        if (Input.GetKeyDown(KeyCode.Z))
            hurtTime = 2.0f;

        if (Input.GetKeyDown(KeyCode.X))
            Anim_Dead = !Anim_Dead;

        if (Input.GetKeyDown(KeyCode.UpArrow))
            Anim_Running = !Anim_Running;

        if(Input.GetKeyDown(KeyCode.RightArrow) && currentRail < 1 && Anim_Running && !GameManager.Instance.BossMode)
        {
            //Anim_RunRight = true;
            MoveRight();
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow) && currentRail > -1 && Anim_Running && !GameManager.Instance.BossMode)
        {
            //Anim_RunLeft = true;
            MoveLeft();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Damaged(1);
        }
        else if (other.CompareTag("FireOfDeath"))
        {
            Damaged(2);
        }
        else if(other.CompareTag("Fireball") && JumpTime == 0.0f)
            Damaged(1);
    }

}
