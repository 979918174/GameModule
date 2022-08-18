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
            if (fsm.GetComponent<PlayerManager>())
            {
                return fsm.GetComponentInChildren<CharacterStatus>().T_AnimaEnd_Attack01;
            }
            else
            {
                return fsm.GetComponent<CharacterStatus>().T_AnimaEnd_Attack01;
            }
            
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.Anima_Attack01End;
        }
    }

}
