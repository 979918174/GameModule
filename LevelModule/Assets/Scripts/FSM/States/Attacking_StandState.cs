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
            //开放输入-注册输入事件
            
            //屏蔽输入-注销输入事件(移动)
            characterInputController.inputActions.Player.Movement.started -= characterInputController.MovementOnstarted;
            characterInputController.inputActions.Player.Movement.performed -= characterInputController.MovementOnperformed;
            characterInputController.inputActions.Player.Movement.canceled -= characterInputController.MovementOncanceled;

            //修改动画参数（bool）
            currentCharacter.GetComponentInChildren<Animator>().SetBool(currentCharacter.GetComponent<PlayerStatus>().CharacterAnimationParameters.attack01, true);
        }

        public override void ExitState(FSMBase fsm)
        {
            characterInputController = fsm.GetComponent<CharacterInputController>();
            currentCharacter = fsm.GetComponent<PlayerManager>().currentCharacter;
            //修改动画参数（bool）
            currentCharacter.GetComponentInChildren<Animator>().SetBool(currentCharacter.GetComponent<PlayerStatus>().CharacterAnimationParameters.attack01, false);
            characterInputController.B_InputAttack01Start= false;
            characterInputController.T_AnimaEnd_Attack01 = false;
            base.ExitState(fsm);
        }
    }
    


}
