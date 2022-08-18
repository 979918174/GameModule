using System.Collections;
using System.Collections.Generic;
using Common;
using UnityEngine;
using GameDemo.Character;
using GameDemo.Skill;
using UnityEngine.InputSystem;

namespace GameDemo.FSM
{
    public class InputAttackStartTrigger : FSMTrigger
    {
        public override bool HandleTrigger(FSMBase fsm)
        {
            return fsm.GetComponent<CharacterInputController>().inputActions.Player.Attack_01.phase == InputActionPhase.Performed ||
                   fsm.GetComponent<CharacterInputController>().inputActions.Player.Attack_01.phase == InputActionPhase.Started||
                   fsm.GetComponent<CharacterInputController>().inputActions.Player.Attack_02.phase == InputActionPhase.Performed ||
                   fsm.GetComponent<CharacterInputController>().inputActions.Player.Attack_02.phase == InputActionPhase.Started;
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.InputAttackStart;
        }
    }

}
