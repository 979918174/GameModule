using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDemo.Character;
using GameDemo.Skill;

namespace GameDemo.FSM
{
    /// <summary>
    /// 没有生命条件
    /// </summary>
    public class AI_AttackRangeTrigger : FSMTrigger
    {
        public override void Init()
        {
            TriggerID = FSMTriggerID.AI_AttackRange;
        }

        public override bool HandleTrigger(FSMBase fsm)
        {
            if ((fsm as FSMBase_Enemy).targetTF)
            {
                return  Vector3.Distance((fsm as FSMBase_Enemy).targetTF.position, fsm.GetComponent<Transform>().position) <= fsm.GetComponent<CharacterSkillManager>().skillDatas[0].attackDistance;
            }
            else
            {
                return false;
            }
        }
    }
}
