using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDemo.Character;

namespace GameDemo.FSM
{
    /// <summary>
    /// 没有生命条件
    /// </summary>
    public class AI_SawTargetTrigger : FSMTrigger
    {
        public override void Init()
        {
            TriggerID = FSMTriggerID.AI_SawTarget;
        }

        public override bool HandleTrigger(FSMBase fsm)
        {
            return (fsm as FSMBase_Enemy).targetTF != null&&Vector3.Distance((fsm as FSMBase_Enemy).targetTF.position, fsm.GetComponent<Transform>().position) > 4f;
        }
    }
}
