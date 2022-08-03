using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDemo.Character;

namespace GameDemo.FSM
{
    /// <summary>
    /// 
    /// </summary>
    public class IdleState : FSMState
    {
        private CharacterInputController characterInputController;
        private GameObject currentCharacter;
        public override void Init()
        {
            StateID = FSMStateID.Idle;
        }

        public override void EnterState(FSMBase fsm)
        {
            currentCharacter = fsm.GetComponent<PlayerManager>().currentCharacter;
            base.EnterState(fsm);
            //修改动画参数
            currentCharacter.GetComponentInChildren<Animator>().SetBool(currentCharacter.GetComponent<PlayerStatus>().CharacterAnimationParameters.idle, true);
        }

        public override void ExitState(FSMBase fsm)
        {
            currentCharacter = fsm.GetComponent<PlayerManager>().currentCharacter;
            fsm.GetComponent<CharacterInputController>().B_InputMoveStart = false;

            currentCharacter.GetComponentInChildren<Animator>().SetBool(currentCharacter.GetComponent<PlayerStatus>().CharacterAnimationParameters.idle, false);
            base.ExitState(fsm);
        }
    }
}
