using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDemo.Character;
using System;
namespace GameDemo.FSM
{
    public class Attacking_MoveState : FSMState
    {
        private CharacterInputController characterInputController;
        private GameObject currentCharacter;
        public override void Init()
        {
            StateID = FSMStateID.Attacking_Move;
        }

        public override void EnterState(FSMBase fsm)
        {
            currentCharacter = fsm.GetComponent<PlayerManager>().currentCharacter;
            //开放输入-注册输入事件
            //屏蔽输入-注销输入事件
            //判断攻击前后摇类型
            //修改动画参数（bool）
            currentCharacter.GetComponentInChildren<Animator>().SetBool(currentCharacter.GetComponent<PlayerStatus>().CharacterAnimationParameters.attack01_move, true);
            base.EnterState(fsm);      
        }
        public override void ActionState(FSMBase fsm)
        {
            base.ActionState(fsm);
            //查找到关键帧释放技能 
        }
        public override void ExitState(FSMBase fsm)
        {
            base.ExitState(fsm);
        }
    }

}
