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
            //��������-ע�������¼�
            characterInputController.inputActions.Player.Movement.started += characterInputController.MovementOnstarted;
            characterInputController.inputActions.Player.Movement.performed += characterInputController.MovementOnperformed;
            characterInputController.inputActions.Player.Movement.canceled += characterInputController.MovementOncanceled;
            //�޸Ķ�������
            currentCharacter.GetComponentInChildren<Animator>().SetBool(currentCharacter.GetComponent<PlayerStatus>().CharacterAnimationParameters.idle, true);
        }

        public override void ExitState(FSMBase fsm)
        {
            currentCharacter = fsm.GetComponent<PlayerManager>().currentCharacter;
            currentCharacter.GetComponentInChildren<Animator>().SetBool(currentCharacter.GetComponent<PlayerStatus>().CharacterAnimationParameters.idle, false);
            //�޸��ж�ϵ��
            fsm.GetComponent<CharacterInputController>().B_InputMoveStart = false;
            base.ExitState(fsm);
        }
    }
}
