using System;
using System.Collections;
using System.Collections.Generic;
using GameDemo.Skill;
using UnityEngine;

namespace GameDemo.Character
{
    /// <summary>
    /// ��ɫ״̬��
    /// </summary>
    public class CharacterStatus : MonoBehaviour
    {
        [Tooltip("��ǰѪ��")]
        public float HP;
        [Tooltip("���Ѫ��")]
        public float MAXHP;
        [Tooltip("������")]
        public float ATK;
        [Tooltip("����")]
        public int SP;
        [Tooltip("��ǰ����ֵ")]
        public int DP;
        [Tooltip("��󻤶�ֵ")]
        public float MAXDP;
        [Tooltip("����")]
        public TypeID type;
        [Tooltip("��ת�ٶ�")]
        public float rotateSpeed;
        [Tooltip("�ƶ��ٶ�")]
        public float moveSpeed;

        public CharacterAnimationParameter CharacterAnimationParameters;

        private float hideTime;
        public void Damage() 
        {
            
        
        }

        //���ø��ִ࣬������
        public virtual void Death() 
        {
            GetComponentInChildren<Animator>().SetBool(CharacterAnimationParameters.dead,true);
        }
        
        public virtual void Break() 
        {
            GetComponentInChildren<Animator>().SetBool(CharacterAnimationParameters.breakdown,true);
        }
        
        public virtual void CoverDP()
        {
            DP += 1;
            hideTime = Time.time + 1;
            
        }
        
        public virtual void Cover() 
        {
            if (DP == MAXDP)
            {
                GetComponentInChildren<Animator>().SetBool(CharacterAnimationParameters.breakdown,false);
            }
        }

        protected void Update()
        {
            if (HP<=0)
            {
                Death();
            }

            if (MAXDP!=0&&DP<=0)
            {
                Break();
            }

            if (GetComponentInChildren<Animator>().GetBool(CharacterAnimationParameters.breakdown))
            {
                if (hideTime <= Time.time)
                            {
                                CoverDP();
                            }
            }

            Cover();
        }
    }
}
