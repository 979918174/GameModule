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
            if (fsm.GetComponent<PlayerManager>())
            {
                return fsm.GetComponentInChildren<CharacterStatus>().IsHurt && fsm.GetComponent<CharacterStatus>().HaveDp == false;
            }
            else
            {
                if (true)
                {
                    return fsm.GetComponent<CharacterStatus>().IsHurt && fsm.GetComponent<CharacterStatus>().HaveDp == false;
                }
                else
                {
                    return false;
                }
            }
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.Impacted;
        }
    }
}