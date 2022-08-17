using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDemo.Character;

namespace GameDemo.FSM
{
    public class MoveState : FSMState
    {
        private GameObject currentCharacter;
        public override void Init()
        {
            StateID = FSMStateID.Move;
        }

        public override void EnterState(FSMBase fsm)
        {
            currentCharacter = fsm.GetComponent<PlayerManager>().currentCharacter;
            
            //注册输入事件
            
            //修改动画参数
            currentCharacter.GetComponentInChildren<Animator>().SetFloat(currentCharacter.GetComponent<PlayerStatus>().CharacterAnimationParameters.speedUPRate,currentCharacter.GetComponentInParent<CharacterMotor>().SpeedUPRate);
            currentCharacter.GetComponentInChildren<Animator>().SetBool(currentCharacter.GetComponent<PlayerStatus>().CharacterAnimationParameters.move,true);
            
        }

        public override void ActionState(FSMBase fsm)
        {
            //实时赋值动画参数速度
            currentCharacter.GetComponentInChildren<Animator>().SetFloat(currentCharacter.GetComponent<PlayerStatus>().CharacterAnimationParameters.speedUPRate, currentCharacter.GetComponentInParent<CharacterMotor>().SpeedUPRate);
            
            
        }

        public override void FixActionState(FSMBase fsm)
        {
            (fsm as FSMBase_Player).characterMotor.Movement((fsm as FSMBase_Player).characterInputController.moveDis);
        }

        public override void ExitState(FSMBase fsm)
        {
            fsm.GetComponent<Rigidbody>().velocity = Vector3.zero;
            //注销输入事件
            //characterInputController.inputActions.Player.Movement.performed -= characterInputController.MovementOnperformed; 
            //修改动画参数
            currentCharacter.GetComponentInChildren<Animator>().SetBool(currentCharacter.GetComponent<PlayerStatus>().CharacterAnimationParameters.move, false);
            currentCharacter.GetComponentInChildren<Animator>().SetFloat(currentCharacter.GetComponent<PlayerStatus>().CharacterAnimationParameters.speedUPRate,currentCharacter.GetComponentInParent<CharacterMotor>().SpeedUPRate);
           
            //修改判断系数
            fsm.GetComponent<CharacterInputController>().B_InputMoveCancel = false;
            //fsm.GetComponent<CharacterInputController>().B_InputAttack01Start = false;
            base.ExitState(fsm);
        }
    }

}
