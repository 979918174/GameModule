using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDemo.Character;
using UnityEngine.InputSystem;

namespace GameDemo.FSM
{
    /// <summary>
    /// 条件：按下移动键
    /// </summary>
    public class InputMoveStartTrigger : FSMTrigger
    {
        public override bool HandleTrigger(FSMBase fsm)
        {
            /*return Keyboard.current.upArrowKey.wasPressedThisFrame|| 
                Keyboard.current.leftArrowKey.wasPressedThisFrame|| 
                Keyboard.current.rightArrowKey.wasPressedThisFrame|| 
                Keyboard.current.downArrowKey.wasPressedThisFrame;*/
            //Gamepad.current.leftStick.ReadValue() != null
            return fsm.GetComponent<CharacterInputController>().inputActions.Player.Movement.phase == InputActionPhase.Performed||
                fsm.GetComponent<CharacterInputController>().inputActions.Player.Movement.phase == InputActionPhase.Started;
            /*return (Keyboard.current.upArrowKey.isPressed ||
            Keyboard.current.leftArrowKey.isPressed ||
            Keyboard.current.rightArrowKey.isPressed ||
            Keyboard.current.downArrowKey.isPressed);*/
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.InputMoveStart;
        }
    }

}
