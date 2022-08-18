using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDemo.Character;
using System;
namespace GameDemo.FSM
{
    public class Attacking_MoveState : FSMState
    {
        private CharacterInputController characterInputController;
        private GameObject currentCharacter;
        public override void Init()
        {
            StateID = FSMStateID.Attacking_Move;
        }

        public override void EnterState(FSMBase fsm)
        {
            currentCharacter = fsm.GetComponent<PlayerManager>().currentCharacter;
            //��������-ע�������¼�
            //��������-ע�������¼�
            //�жϹ���ǰ��ҡ����
            //�޸Ķ���������bool��
            currentCharacter.GetComponentInChildren<Animator>().SetBool(currentCharacter.GetComponent<PlayerStatus>().CharacterAnimationParameters.attack01_move, true);
            base.EnterState(fsm);      
        }
        public override void ActionState(FSMBase fsm)
        {
            base.ActionState(fsm);
            //���ҵ��ؼ�֡�ͷż��� 
        }
        public override void ExitState(FSMBase fsm)
        {
            base.ExitState(fsm);
        }
    }

}
