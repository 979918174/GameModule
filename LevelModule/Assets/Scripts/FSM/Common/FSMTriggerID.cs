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
        InputAttackStart_Move,
        Impacted,
        Anima_AttackedEnd,
        Break,
        BreakToIdle,
        InputChangeStart,
        InputChangeCancel,
        AI_SawTarget,
        AI_AttackRange
    }
}
