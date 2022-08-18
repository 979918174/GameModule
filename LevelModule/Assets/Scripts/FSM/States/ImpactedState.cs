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
            //伤害事件注销判断方法
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
