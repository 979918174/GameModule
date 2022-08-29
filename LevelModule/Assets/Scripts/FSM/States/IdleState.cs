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
            fsm.anim.SetBool(fsm.GetComponent<CharacterStatus>().CharacterAnimationParameters.idle, true);
        }

        public override void ActionState(FSMBase fsm)
        {
          
        }

        public override void ExitState(FSMBase fsm)
        {
            if (fsm.GetComponent<PlayerManager>())
            {
                currentCharacter = fsm.GetComponent<PlayerManager>().currentCharacter;
                fsm.anim.SetBool(currentCharacter.GetComponent<PlayerStatus>().CharacterAnimationParameters.idle, false);
            }
            else
            {
                fsm.anim.SetBool(fsm.GetComponent<CharacterStatus>().CharacterAnimationParameters.idle, false);
            }
          
            base.ExitState(fsm);
        }
    }
}
