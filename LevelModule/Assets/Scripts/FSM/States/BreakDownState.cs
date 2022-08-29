using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDemo.Character;

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
            fsm.anim.SetBool(fsm.chStatus.CharacterAnimationParameters.breakdown, true);  
        }

        public override void ExitState(FSMBase fsm)
        {
            fsm.anim.SetBool(fsm.chStatus.CharacterAnimationParameters.breakdown, false);
        }
    }
}
