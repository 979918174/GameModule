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
            //���Ŷ���
            if (fsm.GetComponent<PlayerManager>())
            {
                //��ʼ����ֵ
                characterInputController = fsm.GetComponent<CharacterInputController>();
                currentCharacter = fsm.GetComponent<PlayerManager>().currentCharacter;
                //�ر�����-ע�������¼�
                characterInputController.inputActions.Player.Movement.started -= characterInputController.MovementOnstarted;
                characterInputController.inputActions.Player.Movement.performed -= characterInputController.MovementOnperformed;
                characterInputController.inputActions.Player.Movement.canceled -= characterInputController.MovementOncanceled;
                characterInputController.inputActions.Player.Attack_01.performed -= characterInputController.Attack_01Onperformed;
                characterInputController.inputActions.Player.Attack_02.performed -= characterInputController.Attack_02Onperformed;
                //�޸Ķ�������
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
            //��ʼ���ж�����
            fsm.GetComponent<CharacterInputController>().B_InputChangeCancel = false;
            fsm.GetComponent<CharacterInputController>().B_InputChangeStart = false;
            //��������-ע�������¼�
            characterInputController.inputActions.Player.Movement.started += characterInputController.MovementOnstarted;
            characterInputController.inputActions.Player.Movement.performed += characterInputController.MovementOnperformed;
            characterInputController.inputActions.Player.Movement.canceled += characterInputController.MovementOncanceled;
            characterInputController.inputActions.Player.Attack_01.performed += characterInputController.Attack_01Onperformed;
            characterInputController.inputActions.Player.Attack_02.performed += characterInputController.Attack_02Onperformed;
        }
    }
}
