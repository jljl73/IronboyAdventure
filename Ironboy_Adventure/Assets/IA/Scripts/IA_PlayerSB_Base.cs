using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_PlayerSB_Base : StateMachineBehaviour
{
    public IA_Player player
    { set; get; }

    readonly int Hash_SpecialGuard = Animator.StringToHash("Special Guard");
    readonly int Hash_Jump = Animator.StringToHash("Jump");
    readonly int Hash_Hurt = Animator.StringToHash("Hurt");
    readonly int Hash_Run = Animator.StringToHash("Run");
    readonly int Hash_Die = Animator.StringToHash("Die");

    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.shortNameHash == Hash_SpecialGuard)
        {
            player.Collider_SpecialGuard.gameObject.SetActive(true);
        }
        else if (stateInfo.shortNameHash == Hash_Jump)
        {
        }
        else if (stateInfo.shortNameHash == Hash_Hurt)
        {
        }
        else if (stateInfo.shortNameHash == Hash_Run)
        {
        }
        else if (stateInfo.shortNameHash == Hash_Die)
        {
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
        if (stateInfo.shortNameHash == Hash_SpecialGuard)
        {
            player.Collider_SpecialGuard.gameObject.SetActive(false);
        }
        else if (stateInfo.shortNameHash == Hash_Jump)
        {
            animator.SetBool("Jump", false);
        }
        else if (stateInfo.shortNameHash == Hash_Hurt)
        {
        }
        else if (stateInfo.shortNameHash == Hash_Run)
        {
        }
        else if (stateInfo.shortNameHash == Hash_Die)
        {
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
