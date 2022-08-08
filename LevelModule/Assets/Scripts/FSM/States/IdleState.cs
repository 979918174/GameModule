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
            base.EnterState(fsm);
            characterInputController = fsm.GetComponent<CharacterInputController>();
            currentCharacter = fsm.GetComponent<PlayerManager>().currentCharacter;
            //开放输入-注册输入事件
            characterInputController.inputActions.Player.Movement.started += characterInputController.MovementOnstarted;
            characterInputController.inputActions.Player.Movement.performed += characterInputController.MovementOnperformed;
            characterInputController.inputActions.Player.Movement.canceled += characterInputController.MovementOncanceled;

            characterInputController.inputActions.Player.Attack_01.performed += characterInputController.Attack_01Onperformed;
            
            //修改动画参数
            currentCharacter.GetComponentInChildren<Animator>().SetBool(currentCharacter.GetComponent<PlayerStatus>().CharacterAnimationParameters.idle, true);
            //初始化判断条件
            fsm.GetComponent<CharacterInputController>().B_InputMoveCancel = false;
            fsm.GetComponent<CharacterInputController>().T_AnimaEnd_Attack01 = true;
        }

        public override void ExitState(FSMBase fsm)
        {
            currentCharacter = fsm.GetComponent<PlayerManager>().currentCharacter;
            currentCharacter.GetComponentInChildren<Animator>().SetBool(currentCharacter.GetComponent<PlayerStatus>().CharacterAnimationParameters.idle, false);
            //修改判断系数
            fsm.GetComponent<CharacterInputController>().B_InputMoveStart = false;
            base.ExitState(fsm);
        }
    }
}
