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
            
            //注册持续输入事件
            characterInputController = fsm.GetComponent<CharacterInputController>();
            characterInputController.inputActions.Player.Movement.performed += characterInputController.MovementOnperformed; 
        }

        public override void ActionState(FSMBase fsm)
        {
            //实时赋值动画参数速度
            currentCharacter.GetComponentInChildren<Animator>().SetFloat(currentCharacter.GetComponent<PlayerStatus>().CharacterAnimationParameters.Speed,currentCharacter.GetComponent<PlayerStatus>().moveSpeed);
            base.ActionState(fsm);
            
        }

        public override void ExitState(FSMBase fsm)
        {
            base.ExitState(fsm);
            //离开移动状态，设置移动动画参数
        }
    }

}
