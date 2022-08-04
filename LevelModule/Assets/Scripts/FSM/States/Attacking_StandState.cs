using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDemo.Character;

namespace GameDemo.FSM
{
    public class Attacking_StandState : FSMState
    {
        private CharacterInputController characterInputController;
        private GameObject currentCharacter;
        public override void Init()
        {
            StateID = FSMStateID.Attacking_Stand;
        }

        public override void EnterState(FSMBase fsm)
        {
            base.EnterState(fsm);
            //开放输入-注册输入事件
            currentCharacter = fsm.GetComponent<PlayerManager>().currentCharacter;
            //屏蔽输入-注销输入事件
            //判断攻击前后摇类型
            //修改动画参数（bool）
            currentCharacter.GetComponentInChildren<Animator>().SetBool(currentCharacter.GetComponent<PlayerStatus>().CharacterAnimationParameters.attack01, true);
        }

        public override void ExitState(FSMBase fsm)
        {
            //修改动画参数（bool）
            currentCharacter.GetComponentInChildren<Animator>().SetBool(currentCharacter.GetComponent<PlayerStatus>().CharacterAnimationParameters.attack01, false);
            base.ExitState(fsm);
        }
    }
    


}
