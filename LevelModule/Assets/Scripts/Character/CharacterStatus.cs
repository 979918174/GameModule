using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Type = Common.Type;

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
        public int GP;
        [Tooltip("最大护盾值")]
        public float MAXGP;
        [Tooltip("属性")]
        public Type type;

        public CharacterAnimationParameter CharacterAnimationParameters;
        public void Damage() 
        {
        
        }

        //调用父类，执行子类
        public virtual void Death() 
        {
            GetComponentInChildren<Animator>().SetBool(CharacterAnimationParameters.dead,true);
        }

        protected void Update()
        {
            if (HP<=0)
            {
                Death();
            }
        }
    }
}
