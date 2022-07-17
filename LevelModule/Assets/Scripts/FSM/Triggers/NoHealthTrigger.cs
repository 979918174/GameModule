using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDemo.FSM
{
    /// <summary>
    /// û����������
    /// </summary>
    public class NoHealthTrigger : FSMTrigger
    {
        public override void Init()
        {
            TriggerID = FSMTriggerID.NoHealth;
        }

        public override bool HandleTrigger(FSMBase fsm)
        {
            return fsm.chStatus.HP <= 0;
        }
    }
}