using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDemo.Character;
namespace GameDemo.FSM
{
    /// <summary>
    /// 死亡状态
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
                //屏蔽操作
                //玩家
                //定时销毁物体
                
                //判断否调用交换 
            }
            else
            {
                if (fsm.GetComponent<EnemyStatus>())
                {
                    //敌人
                    //禁用状态机
                    fsm.enabled = false;
                }
                
            }
            
        }
    }
}
