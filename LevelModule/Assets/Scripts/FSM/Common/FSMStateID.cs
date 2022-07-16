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
        Pursuit,
        Attacking,
        Patrolling
    }
}
