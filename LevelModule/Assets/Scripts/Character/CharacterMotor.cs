using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDemo.Character
{
    /// <summary>
    /// 角色马达：控制旋转和移动
    /// </summary>
    public class CharacterMotor : MonoBehaviour
    {
        //private CharacterController controller;
        public Rigidbody rigidbody;
        [Tooltip("旋转速度")]
        public float rotateSpeed = 20;
        [Tooltip("移动速度")]
        public float moveSpeed = 2;
        private void Start()
        {
            //controller = GetComponent<CharacterController>();
            rigidbody= GetComponent<Rigidbody>();
        }
        //注视方向旋转
        public void LookAtTarget(Vector3 direction)
        {
            //插值
            if (direction == Vector3.zero) return;
            Quaternion LookDir = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, LookDir, rotateSpeed * Time.deltaTime);
        }
        //移动
        public void Movement(Vector3 direction)
        {
            LookAtTarget(direction);
            rigidbody.velocity = direction.normalized * moveSpeed;
            //Vector3 forward = transform.forward;
            //forward.y = -1;
            //controller.Move(transform.forward * Time.deltaTime * moveSpeed);
        }
        
    }
}
