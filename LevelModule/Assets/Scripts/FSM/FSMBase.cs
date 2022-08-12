using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using GameDemo.Character;
using Type = System.Type;

namespace GameDemo.FSM
{
    /// <summary>
    /// ״̬��
    /// </summary>
    public class FSMBase : MonoBehaviour
    {
        [HideInInspector]
        public Animator anim;
        [HideInInspector]
        public CharacterStatus chStatus;
        //״̬�б�
        private List<FSMState> _states;
        public FSMStateID fSMStateID;
        public FSMState currentState;
        //Ĭ��״̬
        private FSMState defaultState;

        [Tooltip("Ĭ��״̬ID")]
        public FSMStateID defaultStateID;

        private void Start()
        {
            InitComponent();
            ConfigFSM();
            //��ʼ��Ĭ��״̬
            InitDefaultState();
        }

        private void InitDefaultState()
        {
            defaultState = ArrayHelper.Find_L(_states, s => s.StateID == defaultStateID);
            currentState = defaultState;
            currentState.EnterState(this);

        }

        //����״̬��������״̬��������״̬��AddMap��
        private void ConfigFSM()
        {
            //����״̬����
            /*for (int i = 0; i < UPPER; i++)
            {
                Type type = Type.GetType("GameDemo.FSM." + sId + "Trigger");
                FSMState state = Activator.CreateInstance(type) as FSMState;
                _states.Add(state);
            }*/
            if (GetComponent<PlayerManager>())
            {
                _states = new List<FSMState>();

                IdleState idle = new IdleState();
                //idle.AddMap(FSMTriggerID.NoHealth,FSMStateID.Dead);
                idle.AddMap(FSMTriggerID.InputMoveStart, FSMStateID.Move);
                idle.AddMap(FSMTriggerID.InputAttackStart, FSMStateID.Attacking_Stand);
                idle.AddMap(FSMTriggerID.NoHealth, FSMStateID.Dead);

                _states.Add(idle);

                DeadState dead = new DeadState();
                _states.Add(dead);

                MoveState move = new MoveState();
                move.AddMap(FSMTriggerID.InputMoveCancel, FSMStateID.Idle);
                move.AddMap(FSMTriggerID.InputAttackStart_Move, FSMStateID.Attacking_Move);
                move.AddMap(FSMTriggerID.NoHealth, FSMStateID.Dead);
                _states.Add(move);

                Attacking_MoveState attacking_MoveState = new Attacking_MoveState();
                attacking_MoveState.AddMap(FSMTriggerID.Anima_Attack01End, FSMStateID.Move);
                attacking_MoveState.AddMap(FSMTriggerID.NoHealth, FSMStateID.Dead);
                _states.Add(attacking_MoveState);

                Attacking_StandState attacking_StandState = new Attacking_StandState();
                attacking_StandState.AddMap(FSMTriggerID.Anima_Attack01End, FSMStateID.Idle);
                attacking_StandState.AddMap(FSMTriggerID.NoHealth, FSMStateID.Dead);
                _states.Add(attacking_StandState);
                //����״̬
            }
            else
            {
                if (true)
                {
                    _states = new List<FSMState>();

                    IdleState idle = new IdleState();
                    //idle.AddMap(FSMTriggerID.NoHealth,FSMStateID.Dead);
                    //idle.AddMap(FSMTriggerID.InputMoveStart, FSMStateID.Move);
                    //idle.AddMap(FSMTriggerID.InputAttackStart, FSMStateID.Attacking_Stand);
                    idle.AddMap(FSMTriggerID.NoHealth, FSMStateID.Dead);
                    idle.AddMap(FSMTriggerID.Impacted, FSMStateID.Impacted);
                    idle.AddMap(FSMTriggerID.Break, FSMStateID.BreakDown);
                    _states.Add(idle);

                    DeadState dead = new DeadState();
                    _states.Add(dead);

                    MoveState move = new MoveState();
                    //move.AddMap(FSMTriggerID.InputMoveCancel, FSMStateID.Idle);
                    //move.AddMap(FSMTriggerID.InputAttackStart_Move, FSMStateID.Attacking_Move);
                    //move.AddMap(FSMTriggerID.NoHealth, FSMStateID.Dead);
                    _states.Add(move);

                    Attacking_MoveState attacking_MoveState = new Attacking_MoveState();
                    //attacking_MoveState.AddMap(FSMTriggerID.Anima_Attack01End, FSMStateID.Move);
                    //attacking_MoveState.AddMap(FSMTriggerID.NoHealth, FSMStateID.Dead);
                    //_states.Add(attacking_MoveState);

                    Attacking_StandState attacking_StandState = new Attacking_StandState();
                    //attacking_StandState.AddMap(FSMTriggerID.Anima_Attack01End, FSMStateID.Idle);
                    //attacking_StandState.AddMap(FSMTriggerID.NoHealth, FSMStateID.Dead);
                    //_states.Add(attacking_StandState);
                    //����״̬
                    ImpactedState impactedState = new ImpactedState();
                    impactedState.AddMap(FSMTriggerID.Anima_AttackedEnd, FSMStateID.Idle);
                    impactedState.AddMap(FSMTriggerID.Break, FSMStateID.BreakDown);
                    _states.Add(impactedState);

                    BreakDownState breakDownState = new BreakDownState();
                    breakDownState.AddMap(FSMTriggerID.BreakToIdle, FSMStateID.Idle);
                    _states.Add(breakDownState);
                }
            }

        }

        public void InitComponent()
        {
            //�ж��Ƿ������
            if (GetComponent<PlayerManager>())
            {
                anim = GetComponentInChildren<Transform>().GetComponentInChildren<Animator>();
                chStatus = GetComponentInChildren<CharacterStatus>();
            }
            else
            {
                //�ж��Ƿ��ǵ���
                if (true)
                {
                    anim = GetComponentInChildren<Animator>();
                    chStatus = GetComponent<EnemyStatus>();
                }
            }
            
        }

        //�л�״̬
        public void ChangeActiveState(FSMStateID stateId)
        {
            //�뿪��һ��״̬
            currentState.ExitState(this);
            //���õ�ǰ״̬
            //�����Ҫ�л���״̬����ǣ�Default��ֱ�ӷ���Ĭ��״̬
            if (stateId == FSMStateID.Default)
            {
                currentState = defaultState;
            }
            else
            {
                //�����״̬�б��в���
                currentState = ArrayHelper.Find_L(_states, s => s.StateID == stateId);
            }
            //������һ��״̬
            currentState.EnterState(this);
        }
        
        
            //û֡�����߼�
        public void Update()
        {
            fSMStateID = currentState.StateID;
            //�ж������Ƿ�����
            currentState.Reason(this);
            //ִ�е�ǰ�߼�
            currentState.ActionState(this);
        }

        
    }
}
