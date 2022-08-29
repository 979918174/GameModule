using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDemo.Character;

namespace GameDemo.FSM
{
    public class MoveState : FSMState
    {
        public override void Init()
        {
            StateID = FSMStateID.Move;
        }

        public override void EnterState(FSMBase fsm)
        {
            //修改动画参数
            fsm.anim.SetFloat(fsm.chStatus.CharacterAnimationParameters.speedUPRate,(fsm as FSMBase_Player).characterMotor.SpeedUPRate);
            fsm.anim.SetBool(fsm.chStatus.CharacterAnimationParameters.move,true);
        }

        public override void ActionState(FSMBase fsm)
        {
            //实时赋值动画参数速度
            fsm.anim.SetFloat(fsm.chStatus.CharacterAnimationParameters.speedUPRate, (fsm as FSMBase_Player).characterMotor.SpeedUPRate);
        }

        public override void FixActionState(FSMBase fsm)
        {
            (fsm as FSMBase_Player).characterMotor.Movement((fsm as FSMBase_Player).characterInputController.moveDis);
        }

        public override void ExitState(FSMBase fsm)
        {
            fsm.GetComponent<Rigidbody>().velocity = Vector3.zero;
            //修改动画参数
            fsm.anim.SetBool(fsm.chStatus.CharacterAnimationParameters.move, false);
            fsm.anim.SetFloat(fsm.chStatus.CharacterAnimationParameters.speedUPRate, (fsm as FSMBase_Player).characterMotor.SpeedUPRate);
            //fsm.GetComponent<CharacterInputController>().B_InputAttack01Start = false;
            base.ExitState(fsm);
        }
    }

}
