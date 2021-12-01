using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_PlayerSB_UpperBody : StateMachineBehaviour
{
    public IA_Player player
    { get; set; }

    readonly int Hash_Horizontal = Animator.StringToHash("Horizontal");
    readonly int Hash_Vertical = Animator.StringToHash("Vertical");
    readonly int Hash_Guard = Animator.StringToHash("Guard");

    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(stateInfo.shortNameHash == Hash_Horizontal)
        {
            player.Collider_HorizontalAttack.gameObject.SetActive(true);
        }
        else if(stateInfo.shortNameHash == Hash_Vertical)
        {
            player.Collider_VerticalAttack.gameObject.SetActive(true);
        }
        else if(stateInfo.shortNameHash == Hash_Guard)
        {
            player.Collider_Guard.gameObject.SetActive(true);
        }
    }

    // OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called before OnStateExit is called on any state inside this state machine
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.shortNameHash == Hash_Horizontal)
        {
            player.Collider_HorizontalAttack.gameObject.SetActive(false);
            animator.SetBool("Horizontal Attack", false);
            animator.SetBool("Vertical Attack", false);
        }
        else if(stateInfo.shortNameHash == Hash_Vertical)
        {
            player.Collider_VerticalAttack.gameObject.SetActive(false);
            animator.SetBool("Horizontal Attack", false);
            animator.SetBool("Vertical Attack", false);
        }
        else if(stateInfo.shortNameHash == Hash_Guard)
        {
            player.Collider_Guard.gameObject.SetActive(false);
        }
    }

    // OnStateMove is called before OnStateMove is called on any state inside this state machine
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateIK is called before OnStateIK is called on any state inside this state machine
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMachineEnter is called when entering a state machine via its Entry Node
    //override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    //{
    //    
    //}

    // OnStateMachineExit is called when exiting a state machine via its Exit Node
    //override public void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    //{
    //    
    //}
}
