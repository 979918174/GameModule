using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDemo.FSM;
using Common;
using GameDemo.Character;
using Type = System.Type;
using GameDemo.Skill;
using UnityEngine.AI;


namespace GameDemo.FSM
{
    public class FSMBase_Player : FSMBase
    {
        public CharacterMotor characterMotor;
        public CharacterInputController characterInputController;
        public override void ConfigFSM()
        {
            _states = new List<FSMState>();

            IdleState idle = new IdleState();
            //idle.AddMap(FSMTriggerID.NoHealth,FSMStateID.Dead);
            idle.AddMap(FSMTriggerID.InputMoveStart, FSMStateID.Move);
            idle.AddMap(FSMTriggerID.InputAttackStart, FSMStateID.Attacking_Stand);
            idle.AddMap(FSMTriggerID.NoHealth, FSMStateID.Dead);
            idle.AddMap(FSMTriggerID.InputChangeStart, FSMStateID.Changing);
            idle.AddMap(FSMTriggerID.Break, FSMStateID.BreakDown);
            idle.AddMap(FSMTriggerID.Impacted, FSMStateID.Impacted);

            _states.Add(idle);

            DeadState dead = new DeadState();
            _states.Add(dead);

            MoveState move = new MoveState();
            move.AddMap(FSMTriggerID.InputMoveCancel, FSMStateID.Idle);
            move.AddMap(FSMTriggerID.NoHealth, FSMStateID.Dead);
            move.AddMap(FSMTriggerID.InputAttackStart, FSMStateID.Attacking_Stand);
            move.AddMap(FSMTriggerID.InputChangeStart, FSMStateID.Changing);
            move.AddMap(FSMTriggerID.Break, FSMStateID.BreakDown);
            move.AddMap(FSMTriggerID.Impacted, FSMStateID.Impacted);
            _states.Add(move);

            Attacking_MoveState attacking_MoveState = new Attacking_MoveState();
            attacking_MoveState.AddMap(FSMTriggerID.Anima_Attack01End, FSMStateID.Move);
            attacking_MoveState.AddMap(FSMTriggerID.NoHealth, FSMStateID.Dead);
            attacking_MoveState.AddMap(FSMTriggerID.Impacted, FSMStateID.Impacted);
            _states.Add(attacking_MoveState);

            Attacking_StandState attacking_StandState = new Attacking_StandState();
            attacking_StandState.AddMap(FSMTriggerID.Anima_Attack01End, FSMStateID.Idle);
            attacking_StandState.AddMap(FSMTriggerID.NoHealth, FSMStateID.Dead);
            attacking_StandState.AddMap(FSMTriggerID.Break, FSMStateID.BreakDown);
            attacking_StandState.AddMap(FSMTriggerID.Impacted, FSMStateID.Impacted);

            _states.Add(attacking_StandState);

            ChangingState changingState = new ChangingState();
            changingState.AddMap(FSMTriggerID.InputChangeCancel, FSMStateID.Idle);
            changingState.AddMap(FSMTriggerID.Impacted, FSMStateID.Impacted);
            _states.Add(changingState);

            BreakDownState breakDownState = new BreakDownState();
            breakDownState.AddMap(FSMTriggerID.BreakToIdle, FSMStateID.Idle);
            _states.Add(breakDownState);

            ImpactedState impactedState = new ImpactedState();
            impactedState.AddMap(FSMTriggerID.Anima_AttackedEnd, FSMStateID.Idle);
            _states.Add(impactedState);


        }

        public override void InitDefaultState() 
        {
            defaultState = ArrayHelper.Find_L(_states, s => s.StateID == defaultStateID);
            currentState = defaultState;
            currentState.EnterState(this);
        }
        public override void InitComponent()
        {
            anim = GetComponentInChildren<Animator>();
            chStatus = GetComponent<CharacterStatus>();
            characterMotor = GetComponent<CharacterMotor>();
            characterInputController = GetComponent<CharacterInputController>();
        }
    }
}
