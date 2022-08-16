using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDemo.FSM
{
    /// <summary>
    /// 
    /// </summary>
    public enum FSMStateID
    {
        None,
        Default,
        Dead,
        Idle,
        Move,
        Attacking_Stand,
        Attacking_Move,
        Changing,
        BreakDown,
        Impacted,
        Enemy_FindPlayer
    }
}
