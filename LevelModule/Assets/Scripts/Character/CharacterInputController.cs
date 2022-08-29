using System;
using System.Collections;
using System.Collections.Generic;
using GameDemo.Skill;
using UnityEngine;
using UnityEngine.InputSystem;
using GameDemo.FSM;

namespace GameDemo.Character
{
    /// <summary>
    /// 角色输入控制器。配合InputSystem
    /// </summary>
    [RequireComponent(typeof(CharacterMotor))]
    public class CharacterInputController : MonoBehaviour
    {
        public InputAction_1 inputActions;
        public Vector3 moveDis = Vector3.zero;
        public PlayerManager playerManager;
        public void Awake()
        {
            //查找组件InputSystem
            inputActions = new InputAction_1();
            playerManager = GetComponentInParent<PlayerManager>();
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
            //交换键下持续
            inputActions.Player.ChangeDown.performed += ChangeDownOnperformed;
            //交换键下取消
            inputActions.Player.ChangeDown.canceled += ChangeDownOncanceled;
            //加速键开始
            inputActions.Player.SpeedUp.started += SpeedUpOnstarted;
            //加速键取消
            inputActions.Player.SpeedUp.canceled += SpeedUpOncanceled;
        }

       

        //加速键弹起：还原马达参数SpeedUPRate
        private void SpeedUpOncanceled(InputAction.CallbackContext obj)
        {
            this.GetComponent<CharacterMotor>().SpeedUPRate /= 2;
        }
        //加速键按下：改变马达参数SpeedUPRate
        private void SpeedUpOnstarted(InputAction.CallbackContext obj)
        {
            this.GetComponent<CharacterMotor>().SpeedUPRate *= 2;
        }

        public void Attack_01Onperformed(InputAction.CallbackContext obj)
        {
            
        }
        public void Attack_02Onperformed(InputAction.CallbackContext obj)
        {
            
        }

        public void ChangeUPOncanceled(InputAction.CallbackContext obj)
        {
            playerManager.ChangeCharacterUp();
        }

        public void ChangeDownOncanceled(InputAction.CallbackContext obj)
        {
            playerManager.ChangeCharacterDown();
        }

        private void ChangeDownOnperformed(InputAction.CallbackContext obj)
        {
            
        }

        private void ChangeUPOnperformed(InputAction.CallbackContext obj)
        {

        }
        
        public void MovementOnstarted(InputAction.CallbackContext obj)
        {
           
        }

        public void MovementOnperformed(InputAction.CallbackContext obj)
        {
            moveDis = new Vector3(obj.ReadValue<Vector2>().x, 0, obj.ReadValue<Vector2>().y);
        }

        public void MovementOncanceled(InputAction.CallbackContext obj)
        {
            moveDis = Vector3.zero;
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
    }
}
