using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDemo.Character;

namespace GameDemo.FSM
{
    /// <summary>
    /// �����������ƶ���
    /// </summary>
    public class InputMoveCancelTrigger : FSMTrigger
    {
        public override bool HandleTrigger(FSMBase fsm)
        {
            return fsm.GetComponent<CharacterInputController>().B_InputMoveCancel;
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.InputMoveCancel;
        }
    }

}
