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
    /// ״̬��
    /// </summary>
    public class FSMBase : MonoBehaviour
    {
        [HideInInspector]
        public Animator anim;
        [HideInInspector]
        public CharacterStatus chStatus;
        //״̬�б�
        public List<FSMState> _states;
        public FSMStateID fSMStateID;
        public FSMState currentState;
        //Ĭ��״̬
        public FSMState defaultState;
        [Tooltip("Ĭ��״̬ID")]
        public FSMStateID defaultStateID;

        public void Start()
        {
            InitComponent();
            ConfigFSM();
            InitDefaultState();
        }

        //����Ĭ��״̬
        public virtual void InitDefaultState()
        {
            
        }

        //����״̬��������״̬��������״̬��AddMap��
        public virtual void ConfigFSM()
        {
            //����״̬����
            /*for (int i = 0; i < UPPER; i++)
            {
                Type type = Type.GetType("GameDemo.FSM." + sId + "Trigger");
                FSMState state = Activator.CreateInstance(type) as FSMState;
                _states.Add(state);
            }*/
        }

        //��ʼ�����
        public virtual void InitComponent()
        {
         
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

        //ÿ֡�����߼�
        public virtual void Update()
        {
            fSMStateID = currentState.StateID;
            //�ж������Ƿ�����
            currentState.Reason(this);
            //ִ�е�ǰ�߼�
            currentState.ActionState(this);
        }
        public virtual void FixedUpdate()
        {
            currentState.FixActionState(this);
        }
    }
}
