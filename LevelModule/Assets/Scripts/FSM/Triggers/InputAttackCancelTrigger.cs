using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDemo.Character;

namespace GameDemo.FSM
{
    /// <summary>
    /// Ìõ¼þ£º
    /// </summary>
    public class InputAttackCancelTrigger : FSMTrigger
    {
        public override bool HandleTrigger(FSMBase fsm)
        {
            return fsm.GetComponent<CharacterInputController>().B_InputAttack01Cancel||fsm.GetComponent<CharacterInputController>().B_InputAttack02Cancel;
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.InputAttackCancel;
        }
    }

}
