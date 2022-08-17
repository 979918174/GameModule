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
        public List<FSMState> _states;
        public FSMStateID fSMStateID;
        public FSMState currentState;
        //默认状态
        public FSMState defaultState;
        [Tooltip("默认状态ID")]
        public FSMStateID defaultStateID;

        public void Start()
        {
            InitComponent();
            ConfigFSM();
            InitDefaultState();
        }

        //设置默认状态
        public virtual void InitDefaultState()
        {
            
        }

        //配置状态机，创建状态对象，设置状态（AddMap）
        public virtual void ConfigFSM()
        {
            //创建状态对象
            /*for (int i = 0; i < UPPER; i++)
            {
                Type type = Type.GetType("GameDemo.FSM." + sId + "Trigger");
                FSMState state = Activator.CreateInstance(type) as FSMState;
                _states.Add(state);
            }*/
        }

        //初始化组件
        public virtual void InitComponent()
        {
         
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

        //每帧处理逻辑
        public virtual void Update()
        {
            fSMStateID = currentState.StateID;
            //判断条件是否满足
            currentState.Reason(this);
            //执行当前逻辑
            currentState.ActionState(this);
        }
        public virtual void FixedUpdate()
        {
            currentState.FixActionState(this);
        }
    }
}
