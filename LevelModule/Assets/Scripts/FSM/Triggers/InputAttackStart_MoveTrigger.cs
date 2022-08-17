using System.Collections;
using System.Collections.Generic;
using Common;
using UnityEngine;
using GameDemo.Character;
using GameDemo.Skill;

namespace GameDemo.FSM
{
    /// <summary>
    /// ????????????????????????????????
    /// </summary>
    public class InputAttackStartTrigger : FSMTrigger
    {
        public override bool HandleTrigger(FSMBase fsm)
        {
            return (fsm.GetComponent<CharacterInputController>().B_InputAttack01Start ||
                    fsm.GetComponent<CharacterInputController>().B_InputAttack02Start) &&
                   fsm.GetComponentInChildren<CharacterSkillManager>().skillDatas[0].skillMoveType ==
                   SkillMoveType.Stand;
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.InputAttackStart;
        }
    }

}
