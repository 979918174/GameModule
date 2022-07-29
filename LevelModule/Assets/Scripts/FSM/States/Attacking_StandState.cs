using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDemo.FSM
{
    public class Attacking_StandState : FSMState
    {
        public override void Init()
        {
            StateID = FSMStateID.Attacking_Stand;
        }
    }


}
