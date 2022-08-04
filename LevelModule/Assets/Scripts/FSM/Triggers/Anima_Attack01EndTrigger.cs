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
        private Animator anim;
        public override bool HandleTrigger(FSMBase fsm)
        {
            anim = fsm.GetComponentInChildren<Animator>();
            //return fsm.GetComponent<CharacterInputController>().T_AnimaEnd_Attack01;
            return anim.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.9f && anim.GetCurrentAnimatorStateInfo(1).IsName("Attack.Fight_attack"); 
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.Anima_Attack01End;
        }
    }

}
