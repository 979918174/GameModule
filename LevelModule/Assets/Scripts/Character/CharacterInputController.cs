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
    [RequireComponent(typeof(CharacterMotor))]
    public class CharacterInputController : MonoBehaviour
    {
        public InputAction_1 inputActions;
        private CharacterMotor _characterMotor;
        private Vector3 moveDis = Vector3.zero;
        public PlayerManager playerManager;
        public GameObject currentPlayer;
        public void Awake()
        {
            //查找组件InputSystem
            inputActions = new InputAction_1();
            _characterMotor = GetComponent<CharacterMotor>();
            playerManager = GetComponent<PlayerManager>();
        }

        public void OnEnable()
        {
            //注册事件
            inputActions.Enable();
            //移动键开始
            inputActions.Player.Movement.started += MovementOnstarted;
            //攻击键01持续
            inputActions.Player.Attack_01.performed += Attack_01Onperformed;
            //攻击键02持续
            inputActions.Player.Attack_02.performed += Attack_02Onperformed;
            //移动键持续
            inputActions.Player.Movement.performed += MovementOnperformed;
            //移动键取消
            inputActions.Player.Movement.canceled += MovementOncanceled;
            //交换键上持续
            inputActions.Player.ChangeUP.performed += ChangeUPOnperformed;
            //交换键上取消
            inputActions.Player.ChangeUP.canceled += ChangeUPOncanceled;
            //交换键下取消
            inputActions.Player.ChangeDown.performed += ChangeDownOnperformed;
            //加速键开始
            inputActions.Player.SpeedUp.started += SpeedUpOnstarted;
            //加速键取消
            inputActions.Player.SpeedUp.canceled += SpeedUpOncanceled;
        }

        private void SpeedUpOncanceled(InputAction.CallbackContext obj)
        {
            throw new NotImplementedException();
        }

        private void SpeedUpOnstarted(InputAction.CallbackContext obj)
        {
            throw new NotImplementedException();
        }

        private void Attack_02Onperformed(InputAction.CallbackContext obj)
        {
            //todo
            moveDis = Vector3.zero;
            currentPlayer.GetComponent<CharacterSkillSystem>().AttackUseSkill(1003);
        }

        private void ChangeUPOncanceled(InputAction.CallbackContext obj)
        {
            
        }

        private void ChangeDownOnperformed(InputAction.CallbackContext obj)
        {
            playerManager.GetComponent<PlayerManager>().ChangeCharacterDown();
        }

        private void ChangeUPOnperformed(InputAction.CallbackContext obj)
        {
         
            playerManager.GetComponent<PlayerManager>().ChangeCharacterUp();
            
        }


        public void MovementOnstarted(InputAction.CallbackContext obj)
        {
            //播放动画
            currentPlayer.GetComponentInChildren<Animator>().SetBool(currentPlayer.GetComponent<PlayerStatus>().CharacterAnimationParameters.run,true);
            Debug.Log("MovementOnstarted");
        }

        public void MovementOnperformed(InputAction.CallbackContext obj)
        {
            //调用马达移动功能
            currentPlayer.GetComponentInChildren<Animator>().SetBool(currentPlayer.GetComponent<PlayerStatus>().CharacterAnimationParameters.run,true);
            moveDis = new Vector3(obj.ReadValue<Vector2>().x, 0, obj.ReadValue<Vector2>().y);
        }

        public void Attack_01Onperformed(InputAction.CallbackContext obj)
        {
            //todo
            moveDis = Vector3.zero;
            currentPlayer.GetComponent<CharacterSkillSystem>().AttackUseSkill(1002);
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
            currentPlayer.GetComponentInChildren<Animator>().SetBool(currentPlayer.GetComponentInChildren<PlayerStatus>().CharacterAnimationParameters.run,false);
        }

        public void OnDisable()
        {
            //注销事件
            inputActions.Player.Movement.started -= MovementOnstarted;
            inputActions.Player.Attack_01.performed -= Attack_01Onperformed;
            inputActions.Player.Attack_02.performed -= Attack_02Onperformed;
            inputActions.Player.Movement.performed -= MovementOnperformed;
            inputActions.Player.Movement.canceled -= MovementOncanceled;
            inputActions.Player.ChangeUP.performed -= ChangeUPOnperformed;
            inputActions.Player.ChangeDown.performed -= ChangeDownOnperformed;
            inputActions.Player.SpeedUp.started -= SpeedUpOnstarted;
            inputActions.Player.SpeedUp.canceled -= SpeedUpOncanceled;
            inputActions.Disable();
        }

        public void FixedUpdate()
        {
            _characterMotor.Movement(moveDis);
        }
        
        
    }
}
