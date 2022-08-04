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
            //��������-ע�������¼�
            currentCharacter = fsm.GetComponent<PlayerManager>().currentCharacter;
            //��������-ע�������¼�
            //�жϹ���ǰ��ҡ����
            //�޸Ķ���������bool��
            currentCharacter.GetComponentInChildren<Animator>().SetBool(currentCharacter.GetComponent<PlayerStatus>().CharacterAnimationParameters.attack01, true);
        }

        public override void ExitState(FSMBase fsm)
        {
            //�޸Ķ���������bool��
            currentCharacter.GetComponentInChildren<Animator>().SetBool(currentCharacter.GetComponent<PlayerStatus>().CharacterAnimationParameters.attack01, false);
            base.ExitState(fsm);
        }
    }
    


}
