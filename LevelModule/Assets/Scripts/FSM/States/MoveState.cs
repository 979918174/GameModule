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
            Debug.Log("FSMStateID.Move");
            base.EnterState(fsm);
            currentCharacter = fsm.GetComponent<PlayerManager>().currentCharacter;
            
            //ע�������¼�
            characterInputController = fsm.GetComponent<CharacterInputController>();
            characterInputController.inputActions.Player.Movement.performed += characterInputController.MovementOnperformed; 
            
            //�޸Ķ�������
            currentCharacter.GetComponentInChildren<Animator>().SetFloat(currentCharacter.GetComponent<PlayerStatus>().CharacterAnimationParameters.SpeedUPRate,currentCharacter.GetComponentInParent<CharacterMotor>().SpeedUPRate);
            currentCharacter.GetComponentInChildren<Animator>().SetBool(currentCharacter.GetComponent<PlayerStatus>().CharacterAnimationParameters.move,true);
            
        }

        public override void ActionState(FSMBase fsm)
        {
            //ʵʱ��ֵ���������ٶ�
            
            base.ActionState(fsm);
            
        }

        public override void ExitState(FSMBase fsm)
        {
            //ע�������¼�
            characterInputController = fsm.GetComponent<CharacterInputController>();
            characterInputController.inputActions.Player.Movement.performed -= characterInputController.MovementOnperformed; 
            //�޸Ķ�������
            currentCharacter.GetComponentInChildren<Animator>().SetFloat(currentCharacter.GetComponent<PlayerStatus>().CharacterAnimationParameters.SpeedUPRate,currentCharacter.GetComponent<CharacterMotor>().SpeedUPRate);
            currentCharacter.GetComponentInChildren<Animator>().SetBool(currentCharacter.GetComponent<PlayerStatus>().CharacterAnimationParameters.move,false);
            base.ExitState(fsm);
        }
    }

}