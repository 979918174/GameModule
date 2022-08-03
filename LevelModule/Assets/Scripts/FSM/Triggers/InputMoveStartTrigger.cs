using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDemo.Character;

namespace GameDemo.FSM
{
    /// <summary>
    /// 条件：按下移动键
    /// </summary>
    public class InputMoveStartTrigger : FSMTrigger
    {
        public override bool HandleTrigger(FSMBase fsm)
        {
            return fsm.GetComponent<CharacterInputController>().B_InputMoveStart;
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.InputMoveStart;
        }
    }

}
