using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using GameDemo.Character;
using Type = System.Type;
using GameDemo.Skill;
using UnityEngine.AI;

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

        public Transform targetTF;
        [Tooltip("����Ŀ���ǩ")]
        public string[] targetTags = {"PlayerManager"};

        [Tooltip("��Ұ����")]
        public float sightDistance = 1000;

        [Tooltip("�ƶ��ٶ�")]
        public float moveSpeed = 2;

        private UnityEngine.AI.NavMeshAgent navMeshAgent;
        private void Start()
        {
            InitComponent();
            ConfigFSM();
            //��ʼ��Ĭ��״̬
            InitDefaultState();
        }

        public void InitDefaultState()
        {
            if (GetComponent<PlayerManager>())
            {
                defaultState = ArrayHelper.Find_L(_states, s => s.StateID == defaultStateID);
                currentState = defaultState;
                currentState.EnterState(this);
            }
            else
            {
                defaultState = ArrayHelper.Find_L(_states, s => s.StateID == FSMStateID.Enemy_FindPlayer);
                currentState = defaultState;
                currentState.EnterState(this);
            }
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
                //����״̬
                ChangingState changingState = new ChangingState();
                changingState.AddMap(FSMTriggerID.InputChangeCancel, FSMStateID.Idle);
                _states.Add(changingState);
            }
            else
            {
                if (true)
                {
                    _states = new List<FSMState>();
                    IdleState idle = new IdleState();
                    //idle.AddMap(FSMTriggerID.InputMoveStart, FSMStateID.Move);
                    //idle.AddMap(FSMTriggerID.InputAttackStart, FSMStateID.Attacking_Stand);
                    idle.AddMap(FSMTriggerID.NoHealth, FSMStateID.Dead);
                    idle.AddMap(FSMTriggerID.Impacted, FSMStateID.Impacted);
                    idle.AddMap(FSMTriggerID.Break, FSMStateID.BreakDown);
                    _states.Add(idle);

                    DeadState dead = new DeadState();
                    _states.Add(dead);

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

                    Enemy_FindPlayerState enemy_FindPlayerState = new Enemy_FindPlayerState();
                    _states.Add(enemy_FindPlayerState);
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
                    navMeshAgent = GetComponent<NavMeshAgent>();
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
            if (GetComponent<EnemyStatus>())
            {
                SearchTarget();
            }
        }

        private void SearchTarget() 
        {
            SkillData data = new SkillData()
            {
                attackTargetTags = targetTags,
                attackDistance = sightDistance,
                attackAngle = 360,
                attackType = SkillAttackType.Group
            };
            Transform[] targetArr = new SectorAttackSelector().SelectTarget(data, transform);
            targetTF = targetArr.Length==0?null:targetArr[0];
        }
        public void MoveToTarget(Vector3 position,float stopDistance,float moveSpeed) 
        {
            //ͨ��Ѱ·���ʵ��
            navMeshAgent.SetDestination(position);
            navMeshAgent.stoppingDistance = stopDistance;
            navMeshAgent.speed = moveSpeed;
        }
    }
}
