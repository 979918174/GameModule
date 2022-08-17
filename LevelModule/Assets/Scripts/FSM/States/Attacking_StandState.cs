using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDemo.Character;

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
            characterInputController = fsm.GetComponent<CharacterInputController>();
            currentCharacter = fsm.GetComponent<PlayerManager>().currentCharacter;
            characterInputController.moveDis =Vector3.zero;
            //开放输入-注册输入事件

            //屏蔽输入-注销输入事件(移动、攻击)
            characterInputController.inputActions.Player.Attack_01.performed -= characterInputController.Attack_01Onperformed;
            characterInputController.inputActions.Player.Attack_02.performed -= characterInputController.Attack_02Onperformed;

            if (characterInputController.B_InputAttack01Start)
            {
                currentCharacter.GetComponentInChildren<Animator>().SetBool(currentCharacter.GetComponent<PlayerStatus>().CharacterAnimationParameters.attack01, true);
            }
            else
            {
                currentCharacter.GetComponentInChildren<Animator>().SetBool(currentCharacter.GetComponent<PlayerStatus>().CharacterAnimationParameters.attack02, true);
            }
            //修改动画参数（bool）
            
            characterInputController.B_InputAttack01Start = false;
            characterInputController.B_InputAttack02Start = false;
            characterInputController.T_AnimaEnd_Attack01 = false;
        }

        public override void ExitState(FSMBase fsm)
        {
            characterInputController = fsm.GetComponent<CharacterInputController>();
            currentCharacter = fsm.GetComponent<PlayerManager>().currentCharacter;
            //修改动画参数（bool）
            currentCharacter.GetComponentInChildren<Animator>().SetBool(currentCharacter.GetComponent<PlayerStatus>().CharacterAnimationParameters.attack01, false);
            currentCharacter.GetComponentInChildren<Animator>().SetBool(currentCharacter.GetComponent<PlayerStatus>().CharacterAnimationParameters.attack02, false);
            characterInputController.B_InputAttack01Start= false;
            characterInputController.B_InputAttack02Start= false;
            characterInputController.T_AnimaEnd_Attack01 = false;
            base.ExitState(fsm);
        }
    }
    


}
