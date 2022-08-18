using System.Collections;
using System.Collections.Generic;
using Common;
using UnityEngine;
using GameDemo.Character;
using GameDemo.Skill;

namespace GameDemo.FSM
{
    /// <summary>
    /// ????????????????????????????????
    /// </summary>
    public class InputAttackStart_MoveTrigger : FSMTrigger
    {
        public override bool HandleTrigger(FSMBase fsm)
        {
            return false;
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.InputAttackStart_Move;
        }
    }

}
