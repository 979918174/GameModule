using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDemo.Character;
namespace GameDemo.FSM
{
    /// <summary>
    /// ����״̬
    /// </summary>
    public class DeadState : FSMState
    {
        public override void Init()
        {
            StateID = FSMStateID.Dead;
            
        }

        public override void EnterState(FSMBase fsm)
        {
            base.EnterState(fsm);
            if (fsm.GetComponent<PlayerManager>())
            {
                //���β���
                //���
                //��ʱ��������
                
                //�жϷ���ý��� 
            }
            else
            {
                if (fsm.GetComponent<EnemyStatus>())
                {
                    //����
                    //����״̬��
                    fsm.enabled = false;
                }
                
            }
            
        }
    }
}
