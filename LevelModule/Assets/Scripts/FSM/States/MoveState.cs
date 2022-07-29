using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDemo.FSM
{
    public class MoveState : FSMState

    {
        public override void Init()
        {
            StateID = FSMStateID.Move;
        }

        public override void EnterState(FSMBase fsm)
        {
            base.EnterState(fsm);
            //�����ƶ�״̬,�����ƶ��������������ƶ�����
        }

        public override void ActionState(FSMBase fsm)
        {
            base.ActionState(fsm);
            //Tick�ƶ�״̬,��ȡInputSystem������Ϣ�����ƶ����
        }

        public override void ExitState(FSMBase fsm)
        {
            base.ExitState(fsm);
            //�뿪�ƶ�״̬�������ƶ���������
        }
    }

}
