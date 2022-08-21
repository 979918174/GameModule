using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDemo.Character;
using UnityEngine.AI;

namespace GameDemo.FSM
{

    /// <summary>
    /// 
    /// </summary>
    public class Enemy_AttackState : FSMState
    {
        public override void Init()
        {
            StateID = FSMStateID.Enemy_Attack;
        }

        public override void EnterState(FSMBase fsm)
        {
            fsm.GetComponentInChildren<Animator>().SetBool(fsm.GetComponent<CharacterStatus>().CharacterAnimationParameters.move, true);
            Debug.Log("222");
        }

        public override void ExitState(FSMBase fsm)
        {
            (fsm as FSMBase_Enemy).navMeshAgent.SetDestination(fsm.GetComponent<Transform>().position);
            fsm.GetComponentInChildren<Animator>().SetBool(fsm.GetComponent<CharacterStatus>().CharacterAnimationParameters.move, false);
        }
    }
}
