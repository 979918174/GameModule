using System;
using System.Collections;
using System.Collections.Generic;
using GameDemo.Skill;
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
        public InputAction_1 inputActions;
        private CharacterMotor _characterMotor;
        private Animator _animator;
        private PlayerStatus _playerStatus;
        private CharacterSkillSystem _skillSystem;
        private Vector3 moveDis = Vector3.zero;
        public void Awake()
        {
            //查找组件InputSystem
            inputActions = new InputAction_1();
            _characterMotor = GetComponent<CharacterMotor>();
            _animator = GetComponentInChildren<Animator>();
            _playerStatus = GetComponent<PlayerStatus>();
            _skillSystem = GetComponent<CharacterSkillSystem>();
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

        
        public void MovementOnstarted(InputAction.CallbackContext obj)
        {
            //播放动画
            _animator.SetBool(_playerStatus.CharacterAnimationParameters.run,true);
        }

        public void MovementOnperformed(InputAction.CallbackContext obj)
        {
            //调用马达移动功能
            _animator.SetBool(_playerStatus.CharacterAnimationParameters.run,true);
            //_characterMotor.Movement(new Vector3(obj.ReadValue<Vector2>().x,0,obj.ReadValue<Vector2>().y));
            moveDis = new Vector3(obj.ReadValue<Vector2>().x, 0, obj.ReadValue<Vector2>().y);
        }

        public void Attack_01Onperformed(InputAction.CallbackContext obj)
        {
            //todo
            moveDis = Vector3.zero;
            _skillSystem.AttackUseSkill(1002);
            /*CharacterSkillManager SkillManager = GetComponent<Skill.CharacterSkillManager>();
            //调用攻击功能,技能管理器
            SkillData skillData = SkillManager.PrePareSkill(1002);
            if (skillData != null) //生成技能
                SkillManager.GenerateSkill(skillData);*/
        }

        public void MovementOncanceled(InputAction.CallbackContext obj)
        {
            //结束动画
            moveDis = Vector3.zero;
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

        public void FixedUpdate()
        {
            _characterMotor.Movement(moveDis);
        }
    }
}
