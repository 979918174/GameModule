using System.Collections;
using UnityEngine;
using GameDemo.Character;
using Common;
namespace GameDemo.FSM
{
    public class ImpactedTrigger : FSMTrigger
    {
        public override bool HandleTrigger(FSMBase fsm)
        {
         return fsm.chStatus.IsHurt && !fsm.chStatus.HaveDp;
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.Impacted;
        }
    }
}