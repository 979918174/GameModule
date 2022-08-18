using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDemo.Character;
using UnityEngine.InputSystem;

namespace GameDemo.FSM
{
    public class Attacking_StandState : FSMState
    {
        private CharacterInputController characterInputController;
        private GameObject currentCharacter;
        public override void Init()
        {
            StateID = FSMStateID.Attacking_Stand;
        }

        public override void EnterState(FSMBase fsm)
        {
            base.EnterState(fsm);
            currentCharacter = fsm.GetComponent<PlayerManager>().currentCharacter;

            if (fsm.GetComponent<CharacterInputController>().inputActions.Player.Attack_01.phase == InputActionPhase.Performed ||
                   fsm.GetComponent<CharacterInputController>().inputActions.Player.Attack_01.phase == InputActionPhase.Started)
            {
                currentCharacter.GetComponentInChildren<Animator>().SetBool(currentCharacter.GetComponent<PlayerStatus>().CharacterAnimationParameters.attack01, true);
            }
            else
            {
                if (fsm.GetComponent<CharacterInputController>().inputActions.Player.Attack_02.phase == InputActionPhase.Performed ||
                   fsm.GetComponent<CharacterInputController>().inputActions.Player.Attack_02.phase == InputActionPhase.Started)
                {
                    currentCharacter.GetComponentInChildren<Animator>().SetBool(currentCharacter.GetComponent<PlayerStatus>().CharacterAnimationParameters.attack02, true);
                }
            }
            //修改动画参数（bool）
           
        }

        public override void ExitState(FSMBase fsm)
        {
            characterInputController = fsm.GetComponent<CharacterInputController>();
            currentCharacter = fsm.GetComponent<PlayerManager>().currentCharacter;
            //修改动画参数（bool）
            currentCharacter.GetComponentInChildren<Animator>().SetBool(currentCharacter.GetComponent<PlayerStatus>().CharacterAnimationParameters.attack01, false);
            currentCharacter.GetComponentInChildren<Animator>().SetBool(currentCharacter.GetComponent<PlayerStatus>().CharacterAnimationParameters.attack02, false);
            //
            currentCharacter.GetComponentInChildren<CharacterStatus>().T_AnimaEnd_Attack01 = false;
            base.ExitState(fsm);
        }
    }
    


}
