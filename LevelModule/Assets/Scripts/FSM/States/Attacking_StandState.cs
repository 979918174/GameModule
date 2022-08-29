using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDemo.Character;
using UnityEngine.InputSystem;

namespace GameDemo.FSM
{
    public class Attacking_StandState : FSMState
    {
        public override void Init()
        {
            StateID = FSMStateID.Attacking_Stand;
        }

        public override void EnterState(FSMBase fsm)
        {
            if ((fsm as FSMBase_Player).characterInputController.inputActions.Player.Attack_01.phase == InputActionPhase.Performed ||
                  (fsm as FSMBase_Player).characterInputController.inputActions.Player.Attack_01.phase == InputActionPhase.Started)
            {
                fsm.anim.SetBool(fsm.chStatus.CharacterAnimationParameters.attack01, true);
            }
            else
            {
                if ((fsm as FSMBase_Player).characterInputController.inputActions.Player.Attack_02.phase == InputActionPhase.Performed ||
                   (fsm as FSMBase_Player).characterInputController.inputActions.Player.Attack_02.phase == InputActionPhase.Started)
                {
                    fsm.anim.SetBool(fsm.chStatus.CharacterAnimationParameters.attack02, true);
                }
            }
            //修改动画参数（bool）
           
        }

        public override void ExitState(FSMBase fsm)
        {
            //修改动画参数（bool）
            fsm.anim.SetBool(fsm.chStatus.CharacterAnimationParameters.attack01, false);
            fsm.anim.SetBool(fsm.chStatus.CharacterAnimationParameters.attack02, false);
            //
            fsm.chStatus.T_AnimaEnd_Attack01 = false;
            base.ExitState(fsm);
        }
    }
    


}
