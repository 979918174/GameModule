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
            base.EnterState(fsm);
            if (fsm.GetComponent<PlayerManager>())
            {

            }
            else
            {
                fsm.GetComponentInChildren<Animator>().SetBool(fsm.GetComponent<CharacterStatus>().CharacterAnimationParameters.breakdown, true);
            }

            //²¥·Å¶¯»­
        }

        public override void ExitState(FSMBase fsm)
        {
            base.ExitState(fsm);
            fsm.GetComponentInChildren<Animator>().SetBool(fsm.GetComponent<CharacterStatus>().CharacterAnimationParameters.breakdown, false);

        }
    }
}
