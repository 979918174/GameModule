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
            //伤害事件注册受击动画播放方法
            EventManager.Instance.AddEventListener<FSMBase>("造成伤害", OnDamageChange);
            //伤害事件注册震动方法
            EventManager.Instance.AddEventListener<FSMBase>("造成伤害", OnShake);
        }

        public override void ActionState(FSMBase fsm)
        {
            base.ActionState(fsm);
            
        }

        public void OnDamageChange(FSMBase fsm) 
        {
            if (fsm.chStatus.passFristAttacked)
            {
                fsm.anim.SetFloat("attackedSpeed", -1f);
            }
        }

        public void OnShake(FSMBase fsm)
        {
            //fsm.GetComponent<CharacterMotor>().Shake();
        }
        public override void ExitState(FSMBase fsm)
        {
            fsm.anim.SetBool(fsm.GetComponent<CharacterStatus>().CharacterAnimationParameters.attacked, false);
            fsm.chStatus.IsHurt = false;
            fsm.chStatus.T_AnimaEnd_Attacked = false;

        }
    }
}
