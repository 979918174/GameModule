using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDemo.FSM
{
    /// <summary>
    /// 状态机
    /// </summary>
    public class FSMBase : MonoBehaviour
    {
        //状态列表
        private List<FSMState> _states;
        
        //配置状态机，创建状态对象，设置状态（AddMap）
        
        //切换状态
        public void ChangeActiveState(FSMStateID stateId)
        {
            //设置当前状态
        }

        public FSMState currentState;
            //没帧处理逻辑
        public void Update()
        {
            //判断条件是否满足
            //执行当前逻辑
            currentState.ActionState();
        }
    }
}
