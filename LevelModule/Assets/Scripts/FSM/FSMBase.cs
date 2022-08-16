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
    /// 状态机
    /// </summary>
    public class FSMBase : MonoBehaviour
    {
        [HideInInspector]
        public Animator anim;
        [HideInInspector]
        public CharacterStatus chStatus;
        //状态列表
        private List<FSMState> _states;
        public FSMStateID fSMStateID;
        public FSMState currentState;
        //默认状态
        private FSMState defaultState;

        [Tooltip("默认状态ID")]
        public FSMStateID defaultStateID;

        public Transform targetTF;
        [Tooltip("攻击目标标签")]
        public string[] targetTags = {"PlayerManager"};

        [Tooltip("视野距离")]
        public float sightDistance = 1000;

        [Tooltip("移动速度")]
        public float moveSpeed = 2;

        private UnityEngine.AI.NavMeshAgent navMeshAgent;
        private void Start()
        {
            InitComponent();
            ConfigFSM();
            //初始化默认状态
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

        //配置状态机，创建状态对象，设置状态（AddMap）
        private void ConfigFSM()
        {
            //创建状态对象
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
                //设置状态
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
                    //设置状态
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
            //判断是否是玩家
            if (GetComponent<PlayerManager>())
            {
                anim = GetComponentInChildren<Transform>().GetComponentInChildren<Animator>();
                chStatus = GetComponentInChildren<CharacterStatus>();
                
            }
            else
            {
                //判断是否是敌人
                if (true)
                {
                    anim = GetComponentInChildren<Animator>();
                    chStatus = GetComponent<EnemyStatus>();
                    navMeshAgent = GetComponent<NavMeshAgent>();
                }
            }
        }

        //切换状态
        public void ChangeActiveState(FSMStateID stateId)
        {
            //离开上一个状态
            currentState.ExitState(this);
            //设置当前状态
            //如果需要切换的状态编号是：Default，直接返回默认状态
            if (stateId == FSMStateID.Default)
            {
                currentState = defaultState;
            }
            else
            {
                //否则从状态列表中查找
                currentState = ArrayHelper.Find_L(_states, s => s.StateID == stateId);
            }
            //进入下一个状态
            currentState.EnterState(this);
        }
        
        
            //没帧处理逻辑
        public void Update()
        {
            fSMStateID = currentState.StateID;
            //判断条件是否满足
            currentState.Reason(this);
            //执行当前逻辑
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
            //通过寻路组件实现
            navMeshAgent.SetDestination(position);
            navMeshAgent.stoppingDistance = stopDistance;
            navMeshAgent.speed = moveSpeed;
        }
    }
}
