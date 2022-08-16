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
            PlayerTrans = GameObject.FindWithTag("PlayerManager");
            if (PlayerTrans)
            {
                fsm.GetComponentInChildren<Animator>().SetBool(fsm.GetComponent<CharacterStatus>().CharacterAnimationParameters.move, true);
                
            }
        }
        public override void ActionState(FSMBase fsm)
        {
            //������������AIѰ·����
            fsm.GetComponent<NavMeshAgent>().destination = PlayerTrans.GetComponent<Transform>().position;
        }

        public override void ExitState(FSMBase fsm)
        {
            fsm.GetComponentInChildren<Animator>().SetBool(fsm.GetComponent<CharacterStatus>().CharacterAnimationParameters.move, true);
        }
    }
}
