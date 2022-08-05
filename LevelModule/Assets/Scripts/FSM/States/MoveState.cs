using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDemo.Character;

namespace GameDemo.FSM
{
    public class MoveState : FSMState
    {
        private CharacterInputController characterInputController;
        private GameObject currentCharacter;
        public override void Init()
        {
            StateID = FSMStateID.Move;
        }

        public override void EnterState(FSMBase fsm)
        {
            base.EnterState(fsm);
            currentCharacter = fsm.GetComponent<PlayerManager>().currentCharacter;
            
            //注册输入事件
            characterInputController = fsm.GetComponent<CharacterInputController>();
            
            //修改动画参数
            currentCharacter.GetComponentInChildren<Animator>().SetFloat(currentCharacter.GetComponent<PlayerStatus>().CharacterAnimationParameters.speedUPRate,currentCharacter.GetComponentInParent<CharacterMotor>().SpeedUPRate);
            currentCharacter.GetComponentInChildren<Animator>().SetBool(currentCharacter.GetComponent<PlayerStatus>().CharacterAnimationParameters.move,true);
            
        }

        public override void ActionState(FSMBase fsm)
        {
            //实时赋值动画参数速度
            currentCharacter.GetComponentInChildren<Animator>().SetFloat(currentCharacter.GetComponent<PlayerStatus>().CharacterAnimationParameters.speedUPRate, currentCharacter.GetComponentInParent<CharacterMotor>().SpeedUPRate);
            base.ActionState(fsm);
            
        }

        public override void ExitState(FSMBase fsm)
        {
            //注销输入事件
            characterInputController = fsm.GetComponent<CharacterInputController>();
            //characterInputController.inputActions.Player.Movement.performed -= characterInputController.MovementOnperformed; 
            //修改动画参数
            currentCharacter.GetComponentInChildren<Animator>().SetFloat(currentCharacter.GetComponent<PlayerStatus>().CharacterAnimationParameters.speedUPRate,currentCharacter.GetComponentInParent<CharacterMotor>().SpeedUPRate);
            currentCharacter.GetComponentInChildren<Animator>().SetBool(currentCharacter.GetComponent<PlayerStatus>().CharacterAnimationParameters.move,false);
            //修改判断系数
            fsm.GetComponent<CharacterInputController>().B_InputMoveCancel = false;
            fsm.GetComponent<CharacterInputController>().B_InputAttack01Start = false;
            base.ExitState(fsm);
        }
    }

}
