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

                _states.Add(idle);

                DeadState dead = new DeadState();
                _states.Add(dead);

                MoveState move = new MoveState();
                move.AddMap(FSMTriggerID.InputMoveCancel, FSMStateID.Idle);
                //move.AddMap(FSMTriggerID.InputAttackStart_Move, FSMStateID.Attacking_Move);
                move.AddMap(FSMTriggerID.NoHealth, FSMStateID.Dead);
                move.AddMap(FSMTriggerID.InputAttackStart, FSMStateID.Attacking_Stand);
                _states.Add(move);

                Attacking_MoveState attacking_MoveState = new Attacking_MoveState();
                attacking_MoveState.AddMap(FSMTriggerID.Anima_Attack01End, FSMStateID.Move);
                attacking_MoveState.AddMap(FSMTriggerID.NoHealth, FSMStateID.Dead);
                _states.Add(attacking_MoveState);

                Attacking_StandState attacking_StandState = new Attacking_StandState();
                attacking_StandState.AddMap(FSMTriggerID.Anima_Attack01End, FSMStateID.Idle);
                attacking_StandState.AddMap(FSMTriggerID.NoHealth, FSMStateID.Dead);
                _states.Add(attacking_StandState);
                //…Ë÷√◊¥Ã¨
                ChangingState changingState = new ChangingState();
                changingState.AddMap(FSMTriggerID.InputChangeCancel, FSMStateID.Idle);
                _states.Add(changingState);
 
        }

        public override void InitDefaultState() 
        {
            if (GetComponent<PlayerManager>())
            {
                defaultState = ArrayHelper.Find_L(_states, s => s.StateID == defaultStateID);
                currentState = defaultState;
                currentState.EnterState(this);
            }
        }
        public override void InitComponent()
        {
            if (GetComponent<PlayerManager>())
            {
                anim = GetComponentInChildren<Transform>().GetComponentInChildren<Animator>();
                chStatus = GetComponentInChildren<CharacterStatus>();
                characterMotor = GetComponent<CharacterMotor>();
                characterInputController = GetComponent<CharacterInputController>();
            }
        }
    }
}
