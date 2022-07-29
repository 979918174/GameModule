using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            base.EnterState(fsm);
            //进入移动状态,设置移动动画参数播放移动动画
        }

        public override void ActionState(FSMBase fsm)
        {
            base.ActionState(fsm);
            //Tick移动状态,获取InputSystem输入信息调用移动马达
        }

        public override void ExitState(FSMBase fsm)
        {
            base.ExitState(fsm);
            //离开移动状态，设置移动动画参数
        }
    }

}
