using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDemo.Character;

namespace GameDemo.FSM
{
    /// <summary>
    /// ���������½�����
    /// </summary>
    public class InputChangeStartTrigger : FSMTrigger
    {
        public override bool HandleTrigger(FSMBase fsm)
        {
            if (fsm.GetComponent<PlayerManager>())
            {
                return fsm.GetComponent<CharacterInputController>().B_InputChangeStart;
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
