using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDemo.FSM
{
    /// <summary>
    /// ״̬��
    /// </summary>
    public class FSMBase : MonoBehaviour
    {
        //״̬�б�
        private List<FSMState> _states;
        
        //����״̬��������״̬��������״̬��AddMap��
        
        //�л�״̬
        public void ChangeActiveState(FSMStateID stateId)
        {
            //���õ�ǰ״̬
        }

        public FSMState currentState;
            //û֡�����߼�
        public void Update()
        {
            //�ж������Ƿ�����
            //ִ�е�ǰ�߼�
            currentState.ActionState();
        }
    }
}
