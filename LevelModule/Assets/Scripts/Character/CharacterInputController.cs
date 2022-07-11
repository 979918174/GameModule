using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameDemo.Character
{
    /// <summary>
    /// 角色输入控制器。配合InputSystem
    /// </summary>
    [RequireComponent(typeof(CharacterMotor),typeof(PlayerStatus))]
    public class CharacterInputController : MonoBehaviour
    {
        private InputAction_1 inputActions;
        private CharacterMotor _characterMotor;
        private Animator _animator;
        private PlayerStatus _playerStatus;
        public void Awake()
        {
            //查找组件InputSystem
            inputActions = new InputAction_1();
            _characterMotor = GetComponent<CharacterMotor>();
            _animator = GetComponentInChildren<Animator>();
            _playerStatus = GetComponent<PlayerStatus>();
        }

        public void OnEnable()
        {
            //注册事件
            inputActions.Enable();
            inputActions.Player.Movement.started += MovementOnstarted;
            inputActions.Player.Attack_01.performed += Attack_01Onperformed;
            inputActions.Player.Movement.performed += MovementOnperformed;
            inputActions.Player.Movement.canceled += MovementOncanceled;
        }

        
        private void MovementOnstarted(InputAction.CallbackContext obj)
        {
            //播放动画
            Debug.Log("2222");
            
            _animator.SetBool(_playerStatus.CharacterAnimationParameters.run,true);
        }

        private void MovementOnperformed(InputAction.CallbackContext obj)
        {
            //调用马达移动功能
            _characterMotor.Movement(new Vector3(obj.ReadValue<Vector2>().x,0,obj.ReadValue<Vector2>().y));
        }

        private void Attack_01Onperformed(InputAction.CallbackContext obj)
        {
            //调用攻击功能
        }

        private void MovementOncanceled(InputAction.CallbackContext obj)
        {
            //结束动画
            _animator.SetBool(_playerStatus.CharacterAnimationParameters.run,false);
        }

        public void OnDisable()
        {
            //注销事件
            inputActions.Player.Movement.started -= MovementOnstarted;
            inputActions.Player.Attack_01.performed -= Attack_01Onperformed;
            inputActions.Player.Movement.performed -= MovementOnperformed;
            inputActions.Player.Movement.canceled -= MovementOncanceled;
            inputActions.Disable();
        }
    }
}