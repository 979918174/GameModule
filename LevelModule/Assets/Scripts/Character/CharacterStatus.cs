using System.Collections;
using System.Collections.Generic;
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
        public CharacterAnimationParameter CharacterAnimationParameters;
        public void Damage() 
        {
        
        }

        //调用父类，执行子类
        public virtual void Death() 
        {
            GetComponent<Animator>().SetBool(CharacterAnimationParameters.run, true);
        }
    }
}
