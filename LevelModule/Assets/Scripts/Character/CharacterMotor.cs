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
        [Tooltip("加速倍率")]
        public float SpeedUPRate = 1;

        public void OnEnable()
        {
            if (!GetComponent<PlayerManager>())
            {
                Shake();
            }
        }
     
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
            transform.rotation = Quaternion.Lerp(transform.rotation, LookDir, GetComponent<PlayerManager>().currentCharacter.GetComponent<PlayerStatus>().rotateSpeed * Time.deltaTime);
        }
        //移动
        public void Movement(Vector3 direction)
        {
            LookAtTarget(direction);
            rigidbody.velocity = direction.normalized * GetComponent<PlayerManager>().currentCharacter.GetComponent<PlayerStatus>().moveSpeed*SpeedUPRate;
            //Vector3 forward = transform.forward;
            //forward.y = -1;
            //controller.Move(transform.forward * Time.deltaTime * moveSpeed);
        }
        public Vector3 shakeRate = new Vector3(0.1f, 0.1f, 0.1f);
        public float shakeTime = 0.5f;
        public float shakeDertaTime = 0.1f;


        public void Shake()
        {
            StartCoroutine(Shake_Coroutine());
        }

        public IEnumerator Shake_Coroutine()
        {
            var oriPosition = gameObject.transform.position;
            for (float i = 0; i < shakeTime; i += shakeDertaTime)
            {
                gameObject.transform.position = oriPosition +
                    UnityEngine.Random.Range(-shakeRate.x, shakeRate.x) * Vector3.right +
                    UnityEngine.Random.Range(-shakeRate.y, shakeRate.y) * Vector3.up +
                    UnityEngine.Random.Range(-shakeRate.z, shakeRate.z) * Vector3.forward;
                yield return new WaitForSeconds(shakeDertaTime);
            }
            gameObject.transform.position = oriPosition;
        }  
    }
}
