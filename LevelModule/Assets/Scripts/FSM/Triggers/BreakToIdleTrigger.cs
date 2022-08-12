using System.Collections;
using UnityEngine;
using GameDemo.Character;
using Common;
namespace GameDemo.FSM
{
    public class BreakToIdleTrigger : FSMTrigger
    {
        public override bool HandleTrigger(FSMBase fsm)
        {
            if (fsm.GetComponent<PlayerManager>())
            {
                return !fsm.GetComponentInChildren<CharacterStatus>().IsBreak;
            }
            else
            {
                if (true)
                {
                    return !fsm.GetComponent<CharacterStatus>().IsBreak;
                }
                else
                {
                    return false;
                }
            }
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.BreakToIdle;

        }
    }
}