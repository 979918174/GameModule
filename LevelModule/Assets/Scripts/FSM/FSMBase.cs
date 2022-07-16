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

        //默认状态
        private FSMState defaultState;

        [Tooltip("默认状态ID")]
        public FSMStateID defaultStateID;

        private void Start()
        {
            InitComponent();
            ConfigFSM();
            //初始化默认状态
            InitDefaultState();
        }

        private void InitDefaultState()
        {
            defaultState = ArrayHelper.Find_L(_states, s => s.StateID == defaultStateID);
            currentState = defaultState;
            currentState.EnterState(this);

        }

        //配置状态机，创建状态对象，设置状态（AddMap）
        private void ConfigFSM()
        {
            _states = new List<FSMState>();
            //创建状态对象
            //Type Type = typeof()
            //设置状态
        }

        public void InitComponent()
        {
            anim = GetComponentInChildren<Animator>();
            chStatus = GetComponent<CharacterStatus>();
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
        
        public FSMState currentState;
            //没帧处理逻辑
        public void Update()
        {
            //判断条件是否满足
            currentState.Reason(this);
            //执行当前逻辑
            currentState.ActionState(this);
        }

        
    }
}
