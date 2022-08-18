using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDemo.Character;

namespace GameDemo.FSM
{
    /// <summary>
    /// 条件：
    /// </summary>
    public class Anima_AttackedEndTrigger : FSMTrigger
    {

        public override bool HandleTrigger(FSMBase fsm)
        {
            if (fsm.GetComponent<PlayerManager>())
            {
                return fsm.GetComponentInChildren<CharacterStatus>().T_AnimaEnd_Attacked;
            }
            else
            {
                return fsm.GetComponent<CharacterStatus>().T_AnimaEnd_Attacked;
            }
            
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.Anima_AttackedEnd;
        }
    }

}
