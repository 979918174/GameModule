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
            fsm.anim.SetBool(fsm.GetComponent<CharacterStatus>().CharacterAnimationParameters.attack01, true);
        }

        public override void ExitState(FSMBase fsm)
        {
            fsm.anim.SetBool(fsm.GetComponent<CharacterStatus>().CharacterAnimationParameters.attack01, false);
            fsm.chStatus.T_AnimaEnd_Attack01 = false;
        }
    }
}
