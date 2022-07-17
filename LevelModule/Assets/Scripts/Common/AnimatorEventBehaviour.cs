using System;
using System.Collections;
using System.Collections.Generic;
using GameDemo.Character;
using UnityEngine;

namespace Common
{
    /// <summary>
    /// 动画事件行为类
    /// </summary>
    public class AnimatorEventBehaviour : MonoBehaviour
    {
        //脚本给到策划
        //为动画片段添加事件，指向OnAttack
        
        //程序
        //在脚本中播放动画，动画中需要执行逻辑，注册
        public event Action attackHandler;
        private Animator anim;
        private InputAction_1 inputActions;
        private CharacterInputController _characterInputController;

        private void Start()
        {
            anim = GetComponent<Animator>();
            //inputActions = GetComponentInParent<CharacterInputController>().inputActions;
            _characterInputController = GetComponentInParent<CharacterInputController>();
        }
    
        //声明事件
        void OnAttack()
        {
            if (attackHandler != null)
            {
                attackHandler();
            }
        }

        void OnCancelAnim(string animParam)
        {
            anim.SetBool(animParam,false);
            if (animParam == "attack01")
            {
                GetComponentInParent<CharacterInputController>().inputActions.Player.Movement.started += _characterInputController.MovementOnstarted;
                GetComponentInParent<CharacterInputController>().inputActions.Player.Movement.performed += _characterInputController.MovementOnperformed;
                GetComponentInParent<CharacterInputController>().inputActions.Player.Movement.canceled += _characterInputController.MovementOncanceled;
            }
        }
    }
}
