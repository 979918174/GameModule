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
            //�˺��¼�ע���жϷ���
            EventManager.Instance.AddEventListener<FSMBase>("����˺�", OnDamageChange);
        }

        public override void ActionState(FSMBase fsm)
        {
            base.ActionState(fsm);
            
        }

        public void OnDamageChange(FSMBase fsm) 
        {
            if (fsm.GetComponentInParent<EnemyStatus>().passFristAttacked)
            {
                fsm.anim.SetFloat("attackedSpeed", -1f);
            }
        }
        public override void ExitState(FSMBase fsm)
        {
            //�˺��¼�ע���жϷ���
            fsm.anim.SetBool(fsm.GetComponent<CharacterStatus>().CharacterAnimationParameters.attacked, false);
            fsm.GetComponent<CharacterStatus>().IsHurt = false;
            fsm.GetComponent<CharacterStatus>().T_AnimaEnd_Attacked = false;
            base.ExitState(fsm);
        }
    }
}
