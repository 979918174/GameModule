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
    public class InputMoveCancelTrigger : FSMTrigger
    {
        public override bool HandleTrigger(FSMBase fsm)
        {
            return !(Keyboard.current.upArrowKey.isPressed ||
                Keyboard.current.leftArrowKey.isPressed ||
                Keyboard.current.rightArrowKey.isPressed ||
                Keyboard.current.downArrowKey.isPressed);
            //Gamepad.current.leftStick.ReadValue() != null
        }

        public override void Init()
        {
            TriggerID = FSMTriggerID.InputMoveCancel;
        }
    }

}
