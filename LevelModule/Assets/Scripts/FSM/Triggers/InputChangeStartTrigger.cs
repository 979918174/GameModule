using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
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
            return fsm.GetComponent<CharacterInputController>().inputActions.Player.ChangeUP.phase == InputActionPhase.Performed||
                   fsm.GetComponent<CharacterInputController>().inputActions.Player.ChangeUP.phase == InputActionPhase.Started||
                   fsm.GetComponent<CharacterInputController>().inputActions.Player.ChangeDown.phase == InputActionPhase.Performed||
                   fsm.GetComponent<CharacterInputController>().inputActions.Player.ChangeDown.phase == InputActionPhase.Started;
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.InputChangeStart;
        }
    }

}
