using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDemo.FSM
{
    /// <summary>
    /// 
    /// </summary>
    public class BreakDownState : FSMState
    {
        public override void Init()
        {
            StateID = FSMStateID.BreakDown;
        }

        public override void EnterState(FSMBase fsm)
        {
            base.EnterState(fsm);
            //²¥·Å¶¯»­
        }

        public override void ExitState(FSMBase fsm)
        {
            base.ExitState(fsm);

        }
    }
}
