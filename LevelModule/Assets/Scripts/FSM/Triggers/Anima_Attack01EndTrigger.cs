using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDemo.Character;

namespace GameDemo.FSM
{
    /// <summary>
    /// Ìõ¼þ£º
    /// </summary>
    public class Anima_Attack01EndTrigger : FSMTrigger
    {
        public override bool HandleTrigger(FSMBase fsm)
        {
            return fsm.GetComponent<CharacterInputController>().T_AnimaEnd_Attack01;
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.Anima_Attack01End;
        }
    }

}
