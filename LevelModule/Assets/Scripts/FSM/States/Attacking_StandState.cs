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
            //��������-ע�������¼�
            
            //��������-ע�������¼�(�ƶ�)
            characterInputController.inputActions.Player.Movement.started -= characterInputController.MovementOnstarted;
            characterInputController.inputActions.Player.Movement.performed -= characterInputController.MovementOnperformed;
            characterInputController.inputActions.Player.Movement.canceled -= characterInputController.MovementOncanceled;

            //�޸Ķ���������bool��
            currentCharacter.GetComponentInChildren<Animator>().SetBool(currentCharacter.GetComponent<PlayerStatus>().CharacterAnimationParameters.attack01, true);
        }

        public override void ExitState(FSMBase fsm)
        {
            characterInputController = fsm.GetComponent<CharacterInputController>();
            currentCharacter = fsm.GetComponent<PlayerManager>().currentCharacter;
            //�޸Ķ���������bool��
            currentCharacter.GetComponentInChildren<Animator>().SetBool(currentCharacter.GetComponent<PlayerStatus>().CharacterAnimationParameters.attack01, false);
            characterInputController.B_InputAttack01Start= false;
            characterInputController.T_AnimaEnd_Attack01 = false;
            base.ExitState(fsm);
        }
    }
    


}
