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
            if (fsm.GetComponent<PlayerManager>())
            {
                //初始化赋值
                characterInputController = fsm.GetComponent<CharacterInputController>();
                currentCharacter = fsm.GetComponent<PlayerManager>().currentCharacter;
                //开放输入-注册输入事件
                characterInputController.inputActions.Player.Movement.started += characterInputController.MovementOnstarted;
                characterInputController.inputActions.Player.Movement.performed += characterInputController.MovementOnperformed;
                characterInputController.inputActions.Player.Movement.canceled += characterInputController.MovementOncanceled;
                characterInputController.inputActions.Player.Attack_01.performed += characterInputController.Attack_01Onperformed;
                characterInputController.inputActions.Player.Attack_02.performed += characterInputController.Attack_02Onperformed;
                //修改动画参数
                currentCharacter.GetComponentInChildren<Animator>().SetBool(currentCharacter.GetComponent<PlayerStatus>().CharacterAnimationParameters.changing, false);
                currentCharacter.GetComponentInChildren<Animator>().SetBool(currentCharacter.GetComponent<PlayerStatus>().CharacterAnimationParameters.idle, true);
                //初始化判断条件
                fsm.GetComponent<CharacterInputController>().T_AnimaEnd_Attack01 = true;
            }
            else 
            {
                fsm.anim.SetBool(fsm.GetComponent<EnemyStatus>().CharacterAnimationParameters.idle, true);
            }
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
