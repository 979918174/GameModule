using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDemo.Character;
using UnityEngine.InputSystem;

namespace GameDemo.FSM
{
    /// <summary>
    /// Ìõ¼þ£º
    /// </summary>
    public class InputAttackCancelTrigger : FSMTrigger
    {
        public override bool HandleTrigger(FSMBase fsm)
        {
            return (fsm.GetComponent<CharacterInputController>().inputActions.Player.Attack_01.phase != InputActionPhase.Performed &&
                   fsm.GetComponent<CharacterInputController>().inputActions.Player.Attack_01.phase != InputActionPhase.Started &&
                   fsm.GetComponent<CharacterInputController>().inputActions.Player.Attack_02.phase != InputActionPhase.Performed &&
                   fsm.GetComponent<CharacterInputController>().inputActions.Player.Attack_02.phase != InputActionPhase.Started);
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.InputAttackCancel;
        }
    }

}
