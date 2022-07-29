using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameDemo.FSM
{
    public class Attacking_MoveState : FSMState
    {
        public override void Init()
        {
            StateID = FSMStateID.Attacking_Move;
        }

        public override void EnterState(FSMBase fsm)
        {
            base.EnterState(fsm);
        }

        public override void ExitState(FSMBase fsm)
        {
            base.ExitState(fsm);
        }
    }

}
