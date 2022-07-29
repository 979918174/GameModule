using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDemo.FSM
{
    /// <summary>
    /// 
    /// </summary>
    public class ChangingState : FSMState
    {
        public override void Init()
        {
            StateID = FSMStateID.Changing;
        }

        public override void EnterState(FSMBase fsm)
        {
            base.EnterState(fsm);
            //���Ŷ���
        }

        public override void ExitState(FSMBase fsm)
        {
            base.ExitState(fsm);
        }
    }
}
