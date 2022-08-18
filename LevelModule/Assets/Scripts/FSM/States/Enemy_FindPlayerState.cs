using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDemo.Character;
using UnityEngine.AI;

namespace GameDemo.FSM
{

    /// <summary>
    /// 
    /// </summary>
    public class Enemy_FindPlayerState : FSMState
    {
        public GameObject PlayerTrans;
        public override void Init()
        {
            StateID = FSMStateID.Enemy_FindPlayer;
        }

        public override void EnterState(FSMBase fsm)
        {
            fsm.GetComponentInChildren<Animator>().SetBool(fsm.GetComponent<CharacterStatus>().CharacterAnimationParameters.move, true);
        }
        public override void ActionState(FSMBase fsm)
        {
            //更新玩家坐标给AI寻路参数
            (fsm as FSMBase_Enemy).MoveToTarget((fsm as FSMBase_Enemy).targetTF.position, (fsm as FSMBase_Enemy).chStatus.attackDistance, (fsm as FSMBase_Enemy).moveSpeed);
        }

        public override void ExitState(FSMBase fsm)
        {
            fsm.GetComponentInChildren<Animator>().SetBool(fsm.GetComponent<CharacterStatus>().CharacterAnimationParameters.move, false);
        }
    }
}
