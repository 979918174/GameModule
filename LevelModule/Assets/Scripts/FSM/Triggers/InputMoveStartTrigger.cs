using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDemo.Character;

namespace GameDemo.FSM
{
    /// <summary>
    /// �����������ƶ���
    /// </summary>
    public class InputMoveStartTrigger : FSMTrigger
    {
        public override bool HandleTrigger(FSMBase fsm)
        {
            if (fsm.GetComponent<PlayerManager>())
            {
                return fsm.GetComponent<CharacterInputController>().B_InputMoveStart;
            }
            else
            {
                return false;
            }
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.InputMoveStart;
        }
    }

}
