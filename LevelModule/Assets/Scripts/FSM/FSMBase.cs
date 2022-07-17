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

        //Ĭ��״̬
        private FSMState defaultState;

        [Tooltip("Ĭ��״̬ID")]
        public FSMStateID defaultStateID;

        private void Start()
        {
            InitComponent();
            ConfigFSM();
            //��ʼ��Ĭ��״̬
            InitDefaultState();
        }

        private void InitDefaultState()
        {
            defaultState = ArrayHelper.Find_L(_states, s => s.StateID == defaultStateID);
            currentState = defaultState;
            currentState.EnterState(this);

        }

        //����״̬��������״̬��������״̬��AddMap��
        private void ConfigFSM()
        {
            _states = new List<FSMState>();
            //����״̬����
            /*for (int i = 0; i < UPPER; i++)
            {
                Type type = Type.GetType("GameDemo.FSM." + sId + "Trigger");
                FSMState state = Activator.CreateInstance(type) as FSMState;
                _states.Add(state);
            }*/
            IdleState idle = new IdleState();
            idle.AddMap(FSMTriggerID.NoHealth,FSMStateID.Dead);
            _states.Add(idle);
            
            DeadState dead = new DeadState();
            _states.Add(dead);
            
            //����״̬
        }

        public void InitComponent()
        {
            anim = GetComponentInChildren<Animator>();
            chStatus = GetComponent<CharacterStatus>();
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
        
        public FSMState currentState;
            //û֡�����߼�
        public void Update()
        {
            //�ж������Ƿ�����
            currentState.Reason(this);
            //ִ�е�ǰ�߼�
            currentState.ActionState(this);
        }

        
    }
}