using System;
using System.Collections;
using System.Collections.Generic;
using GameDemo.Character;
using UnityEngine;

namespace Common
{
    /// <summary>
    /// �����¼���Ϊ��
    /// </summary>
    public class AnimatorEventBehaviour : MonoBehaviour
    {
        //�ű������߻�
        //Ϊ����Ƭ������¼���ָ��OnAttack
        
        //����
        //�ڽű��в��Ŷ�������������Ҫִ���߼���ע��
        public event Action attackHandler;

        private Animator anim;

        private void Start()
        {
            anim = GetComponent<Animator>();
        }
    
        //�����¼�
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
        }
    }
}
