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
            //播放动画
            fsm.anim.SetBool(fsm.GetComponent<CharacterStatus>().CharacterAnimationParameters.attacked, true);
            //伤害事件注册判断方法
            EventManager.Instance.AddEventListener<FSMBase>("造成伤害", OnDamageChange);
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
            //伤害事件注销判断方法
            fsm.anim.SetBool(fsm.GetComponent<CharacterStatus>().CharacterAnimationParameters.attacked, false);
            fsm.GetComponent<CharacterStatus>().IsHurt = false;
            fsm.GetComponent<CharacterStatus>().T_AnimaEnd_Attacked = false;
            base.ExitState(fsm);
        }
    }
}
