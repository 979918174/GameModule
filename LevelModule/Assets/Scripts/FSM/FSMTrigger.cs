using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDemo.FSM
{
    /// <summary>
    /// ������
    /// </summary>
    public abstract class FSMTrigger
    {
        //���
        public FSMTriggerID TriggerID { get; set; }

        public FSMTrigger()
        {
            Init();
        }
        //��������ʼ��������Ϊ��Ÿ�ֵ
        public abstract void Init();

        //�߼�����
        public abstract bool HandleTrigger();
    }
}
