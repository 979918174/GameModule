using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDemo.Character;

namespace GameDemo.FSM
{
    /// <summary>
    /// 
    /// </summary>
    public class ChangingState : FSMState
    {
        private CharacterInputController characterInputController;
        private GameObject currentCharacter;
        public override void Init()
        {
            StateID = FSMStateID.Changing;
        }

        public override void EnterState(FSMBase fsm)
        {
            base.EnterState(fsm);
            //初始化赋值
            characterInputController = fsm.GetComponent<CharacterInputController>();
            currentCharacter = fsm.GetComponent<PlayerManager>().currentCharacter;
            //修改动画参数
            currentCharacter.GetComponentInChildren<Animator>()
                .SetBool(currentCharacter.GetComponent<PlayerStatus>().CharacterAnimationParameters.changing, true);
        }

        public override void ExitState(FSMBase fsm)
        {
            Debug.Log("bianshengover");
            base.ExitState(fsm);
        }
    }
}
