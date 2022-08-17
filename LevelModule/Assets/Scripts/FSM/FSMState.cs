using System.Collections;
using System.Collections.Generic;
using Common;
using UnityEngine;
using System;
using Type = System.Type;

namespace GameDemo.FSM
{
    /// <summary>
    /// 状态类
    /// </summary>
    public abstract class FSMState
    {
        public FSMStateID StateID { set; get; }

        //映射表
        private Dictionary<FSMTriggerID, FSMStateID> map;

        //条件列表
        private List<FSMTrigger> Triggers;
        
        public FSMState()
        {
            map = new Dictionary<FSMTriggerID, FSMStateID>();
            Triggers = new List<FSMTrigger>();
            Init(); 
        }
        public abstract void Init();

        //由状态机调用
        public void AddMap(FSMTriggerID triggerId,FSMStateID stateId)
        {
            //添加映射
            map.Add(triggerId,stateId);
            //创建条件对象,命名规范 GameDemo.FSM + 条件枚举 + Trigger
            CreateTrigger(triggerId);
        }

        private void CreateTrigger(FSMTriggerID triggerId)
        {
            Type type = Type.GetType("GameDemo.FSM." + triggerId + "Trigger");
            FSMTrigger trigger = Activator.CreateInstance(type) as FSMTrigger;
            Triggers.Add(trigger);
        }

        public virtual void EnterState(FSMBase fsm) { }

        public virtual void ActionState(FSMBase fsm) { }

        public virtual void ExitState(FSMBase fsm) { }

        public virtual void FixActionState(FSMBase fsm) { }

        //检测当前状态的条件是否满足
        public void Reason(FSMBase fsm)
        {
            for (int i = 0; i < Triggers.Count; i++)
            {
                if (Triggers[i].HandleTrigger(fsm))
                {
                    //切换状态
                    FSMStateID stateId = map[Triggers[i].TriggerID];
                    fsm.ChangeActiveState(stateId);
                    return;
                }
            }
        }
    }
}
