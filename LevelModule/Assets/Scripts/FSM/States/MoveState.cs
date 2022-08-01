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
            
            //ע����������¼�
            characterInputController = fsm.GetComponent<CharacterInputController>();
            characterInputController.inputActions.Player.Movement.performed += characterInputController.MovementOnperformed; 
        }

        public override void ActionState(FSMBase fsm)
        {
            //ʵʱ��ֵ���������ٶ�
            currentCharacter.GetComponentInChildren<Animator>().SetFloat(currentCharacter.GetComponent<PlayerStatus>().CharacterAnimationParameters.Speed,currentCharacter.GetComponent<PlayerStatus>().moveSpeed);
            base.ActionState(fsm);
            
        }

        public override void ExitState(FSMBase fsm)
        {
            base.ExitState(fsm);
            //�뿪�ƶ�״̬�������ƶ���������
        }
    }

}
