using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDemo.Character;
using Common;

namespace GameDemo.FSM
{
    /// <summary>
    /// 
    /// </summary>
    public class ImpactedState : FSMState
    {
        public override void Init()
        {
            StateID = FSMStateID.Impacted;
        }

        public override void EnterState(FSMBase fsm)
        {
            base.EnterState(fsm);
            //���Ŷ���
            fsm.anim.SetBool(fsm.GetComponent<CharacterStatus>().CharacterAnimationParameters.attacked, true);
            //�˺��¼�ע���ܻ��������ŷ���
            EventManager.Instance.AddEventListener<FSMBase>("����˺�", OnDamageChange);
            //�˺��¼�ע���𶯷���
            EventManager.Instance.AddEventListener<FSMBase>("����˺�", OnShake);
        }

        public override void ActionState(FSMBase fsm)
        {
            base.ActionState(fsm);
            
        }

        public void OnDamageChange(FSMBase fsm) 
        {
            if (fsm.GetComponent<PlayerManager>())
            {
                if (fsm.GetComponent<PlayerManager>().currentCharacter.GetComponent<PlayerStatus>().passFristAttacked)
                {
                    fsm.anim.SetFloat("attackedSpeed", -1f);
                }
            }
            else
            {
                if (fsm.GetComponent<EnemyStatus>().passFristAttacked)
                {
                    fsm.anim.SetFloat("attackedSpeed", -1f);
                }
            }
        }

        public void OnShake(FSMBase fsm)
        {
            //fsm.GetComponent<CharacterMotor>().Shake();
        }
        public override void ExitState(FSMBase fsm)
        {
            fsm.anim.SetBool(fsm.GetComponent<CharacterStatus>().CharacterAnimationParameters.attacked, false);
            //�˺��¼�ע���жϷ���
            if (fsm.GetComponent<PlayerManager>())
            {
                fsm.GetComponent<PlayerManager>().currentCharacter.GetComponent<PlayerStatus>().IsHurt = false;
                fsm.GetComponent<PlayerManager>().currentCharacter.GetComponent<PlayerStatus>().T_AnimaEnd_Attacked = false;
            }
            else
            {
                fsm.GetComponent<CharacterStatus>().IsHurt = false;
                fsm.GetComponent<CharacterStatus>().T_AnimaEnd_Attacked = false;
            }

        }
    }
}
