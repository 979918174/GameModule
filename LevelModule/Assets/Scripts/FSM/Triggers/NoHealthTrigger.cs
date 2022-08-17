using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDemo.Character;

namespace GameDemo.FSM
{
    /// <summary>
    /// 没有生命条件
    /// </summary>
    public class NoHealthTrigger : FSMTrigger
    {
        public override void Init()
        {
            TriggerID = FSMTriggerID.NoHealth;
        }

        public override bool HandleTrigger(FSMBase fsm)
        {
            if (fsm.GetComponent<PlayerManager>())
            {
                return fsm.chStatus.HP <= 0;
            }
            else
            {
                return false;
            }
            
        }
    }
}
