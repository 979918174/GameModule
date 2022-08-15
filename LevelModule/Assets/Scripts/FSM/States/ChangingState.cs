using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDemo.Character;

namespace GameDemo.FSM
{
    /// <summary>
    /// 
    /// </summary>
    public class ChangingState : FSMState
    {
        private CharacterInputController characterInputController;
        private GameObject currentCharacter;
        public override void Init()
        {
            StateID = FSMStateID.Changing;
        }

        public override void EnterState(FSMBase fsm)
        {
            base.EnterState(fsm);
            Debug.Log("biansheng");
            //播放动画
            if (fsm.GetComponent<PlayerManager>())
            {
                //初始化赋值
                characterInputController = fsm.GetComponent<CharacterInputController>();
                currentCharacter = fsm.GetComponent<PlayerManager>().currentCharacter;
                //关闭输入-注销输入事件
                characterInputController.inputActions.Player.Movement.started -= characterInputController.MovementOnstarted;
                characterInputController.inputActions.Player.Movement.performed -= characterInputController.MovementOnperformed;
                characterInputController.inputActions.Player.Movement.canceled -= characterInputController.MovementOncanceled;
                characterInputController.inputActions.Player.Attack_01.performed -= characterInputController.Attack_01Onperformed;
                characterInputController.inputActions.Player.Attack_02.performed -= characterInputController.Attack_02Onperformed;
                //修改动画参数
                currentCharacter.GetComponentInChildren<Animator>().SetBool(currentCharacter.GetComponent<PlayerStatus>().CharacterAnimationParameters.changing, true);
                fsm.GetComponent<CharacterInputController>().B_InputChangeCancel = false;
                fsm.GetComponent<CharacterInputController>().B_InputChangeStart = false;
            }
            else
            {
                fsm.anim.SetBool(fsm.GetComponent<EnemyStatus>().CharacterAnimationParameters.changing, true);
            }
        }

        public override void ExitState(FSMBase fsm)
        {
            Debug.Log("bianshengover");
            base.ExitState(fsm);
            //初始化判断条件
            fsm.GetComponent<CharacterInputController>().B_InputChangeCancel = false;
            fsm.GetComponent<CharacterInputController>().B_InputChangeStart = false;
            //开放输入-注册输入事件
            characterInputController.inputActions.Player.Movement.started += characterInputController.MovementOnstarted;
            characterInputController.inputActions.Player.Movement.performed += characterInputController.MovementOnperformed;
            characterInputController.inputActions.Player.Movement.canceled += characterInputController.MovementOncanceled;
            characterInputController.inputActions.Player.Attack_01.performed += characterInputController.Attack_01Onperformed;
            characterInputController.inputActions.Player.Attack_02.performed += characterInputController.Attack_02Onperformed;
        }
    }
}
