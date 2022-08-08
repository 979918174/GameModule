using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDemo.FSM
{
    /// <summary>
    /// 
    /// </summary>
    public enum FSMTriggerID
    {
        NoHealth,
        SawTarget,
        ReachTarget,
        KilledTarget,
        WithoutAttackRange,
        LoseTarget,
        CompletePatrol,
        InputMoveStart,
        InputMoveCancel,
        InputAttackStart,
        InputAttackCancel,
        Anima_Attack01End,
        InputAttackStart_Move
    }
}
