using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDemo.Character;

namespace GameDemo.FSM
{
    /// <summary>
    /// 条件：按下交换键
    /// </summary>
    public class InputChangeCancelTrigger : FSMTrigger
    {
        public override bool HandleTrigger(FSMBase fsm)
        {
            if (fsm.GetComponent<PlayerManager>())
            {
                return fsm.GetComponent<CharacterInputController>().B_InputChangeCancel;
            }
            else
            {
                return false;
            }
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.InputChangeStart;
        }
    }

}
