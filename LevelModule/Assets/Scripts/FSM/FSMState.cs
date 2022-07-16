using System.Collections;
using System.Collections.Generic;
using Common;
using UnityEngine;
using System;
using Type = System.Type;

namespace GameDemo.FSM
{
    /// <summary>
    /// ״̬��
    /// </summary>
    public abstract class FSMState
    {
        public FSMStateID StateID { set; get; }

        //ӳ���
        private Dictionary<FSMTriggerID, FSMStateID> map;

        //�����б�
        private List<FSMTrigger> Triggers;
        
        public FSMState()
        {
            map = new Dictionary<FSMTriggerID, FSMStateID>();
            Triggers = new List<FSMTrigger>();
            Init(); 
        }
        public abstract void Init();

        //��״̬������
        public void AddMap(FSMTriggerID triggerId,FSMStateID stateId)
        {
            //���ӳ��
            map.Add(triggerId,stateId);
            //������������,�����淶 GameDemo.FSM + ����ö�� + Trigger
            CreateTrigger(triggerId);
        }

        private void CreateTrigger(FSMTriggerID triggerId)
        {
            Type type = Type.GetType("GameDemo.FSM." + triggerId + "Trigger");
            FSMTrigger trigger = Activator.CreateInstance(type) as FSMTrigger;
            Triggers.Add(trigger);
        }

        public virtual void EnterState() { }

        public virtual void ActionState() { }

        public virtual void ExitState() { }
    }
}
