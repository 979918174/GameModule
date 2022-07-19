using System;
using System.Collections;
using System.Collections.Generic;
using GameDemo.Skill;
using UnityEngine;

namespace GameDemo.Character
{
    /// <summary>
    /// 角色状态类
    /// </summary>
    public class CharacterStatus : MonoBehaviour
    {
        [Tooltip("当前血量")]
        public float HP;
        [Tooltip("最大血量")]
        public float MAXHP;
        [Tooltip("攻击力")]
        public float ATK;
        [Tooltip("能量")]
        public int SP;
        [Tooltip("当前护盾值")]
        public int DP;
        [Tooltip("最大护盾值")]
        public float MAXDP;
        [Tooltip("属性")]
        public TypeID type;
        [Tooltip("旋转速度")]
        public float rotateSpeed;
        [Tooltip("移动速度")]
        public float moveSpeed;

        public CharacterAnimationParameter CharacterAnimationParameters;

        private float hideTime;
        public void Damage() 
        {
            
        
        }

        //调用父类，执行子类
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
