using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDemo.Character;

namespace GameDemo.FSM
{
    /// <summary>
    /// �����������ƶ���
    /// </summary>
    public class InputAttackStartTrigger : FSMTrigger
    {
        public override bool HandleTrigger(FSMBase fsm)
        {
            return (fsm.GetComponent<CharacterInputController>().B_InputAttack01Start|| fsm.GetComponent<CharacterInputController>().B_InputAttack02Start)&&fsm.GetComponent<CharacterInputController>().T_AnimaEnd_Attack01;
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.InputAttackStart;
        }
    }

}
