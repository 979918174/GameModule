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
            //return fsm.GetComponent<CharacterInputController>().T_AnimaEnd_Attack01;
            return fsm.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(1).normalizedTime > 0.9f && fsm.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(1).IsName("Attack.Fight_attack"); 
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.Anima_Attack01End;
        }
    }

}
