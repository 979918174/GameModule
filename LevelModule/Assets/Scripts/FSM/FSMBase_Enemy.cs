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
    public class FSMBase_Enemy : FSMBase
    {
        public UnityEngine.AI.NavMeshAgent navMeshAgent;

        public Transform targetTF = null;

        [Tooltip("攻击目标标签")]
        public string[] targetTags = { "PlayerManager" };

        [Tooltip("视野距离")]
        public float sightDistance = 1000;

        [Tooltip("移动速度")]
        public float moveSpeed = 2;
        public override void ConfigFSM()
        {
            _states = new List<FSMState>();

            IdleState idle = new IdleState();
            idle.AddMap(FSMTriggerID.AI_SawTarget, FSMStateID.Enemy_FindPlayer);
            idle.AddMap(FSMTriggerID.Break, FSMStateID.BreakDown);
            idle.AddMap(FSMTriggerID.Impacted, FSMStateID.Impacted);
            idle.AddMap(FSMTriggerID.AI_AttackRange,FSMStateID.Enemy_Attack);
            _states.Add(idle);

            Enemy_FindPlayerState enemy_FindPlayerState = new Enemy_FindPlayerState();
            enemy_FindPlayerState.AddMap(FSMTriggerID.Break, FSMStateID.BreakDown);
            enemy_FindPlayerState.AddMap(FSMTriggerID.Impacted, FSMStateID.Impacted);
            enemy_FindPlayerState.AddMap(FSMTriggerID.AI_AttackRange,FSMStateID.Enemy_Attack);
            _states.Add(enemy_FindPlayerState);


            BreakDownState breakDownState = new BreakDownState();
            breakDownState.AddMap(FSMTriggerID.BreakToIdle, FSMStateID.Idle);
            _states.Add(breakDownState);

            ImpactedState impactedState = new ImpactedState();
            impactedState.AddMap(FSMTriggerID.Anima_AttackedEnd, FSMStateID.Idle);
            _states.Add(impactedState);
            
            Enemy_AttackState enemyAttackState = new Enemy_AttackState();
            enemyAttackState.AddMap(FSMTriggerID.Impacted, FSMStateID.Impacted);
            enemyAttackState.AddMap(FSMTriggerID.Anima_Attack01End,FSMStateID.Idle);
            _states.Add(enemyAttackState);
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
            chStatus = GetComponent<EnemyStatus>();
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        public void MoveToTarget(Vector3 position, float stopDistance, float moveSpeed)
        {
            //通过寻路组件实现
            navMeshAgent.SetDestination(position);
            navMeshAgent.stoppingDistance = stopDistance;
            navMeshAgent.speed = moveSpeed;
        }

        public void SearchTarget()
        {
            SkillData data = new SkillData()
            {
                attackTargetTags = targetTags,
                attackDistance = sightDistance,
                attackAngle = 360,
                attackType = SkillAttackType.Group
            };
            Transform[] targetArr = new SectorAttackSelector().SelectTarget(data, transform);
            targetTF = targetArr.Length == 0 ? null : targetArr[0];
        }

        public override void Update()
        {
            base.Update();
            SearchTarget();
        }
    }
}