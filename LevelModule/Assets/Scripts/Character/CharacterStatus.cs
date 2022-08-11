using System;
using System.Collections;
using System.Collections.Generic;
using Common;
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
        public int MAXDP;
        [Tooltip("属性")]
        public TypeID type;
        [Tooltip("旋转速度")]
        public float rotateSpeed;
        [Tooltip("移动速度")]
        public float moveSpeed;
        [Tooltip("受击时间")]

        //动画相关判断值
        public bool passFristAttacked;
        [Tooltip("是否首次受击")]
        public float hurtTime;
        [Tooltip("是否受击")]
        public bool IsHurt;
        [Tooltip("受击是否结束")]
        public bool T_AnimaEnd_Attacked;
        [Tooltip("是否有护盾")] 
        public bool HaveDp;
        public CharacterAnimationParameter CharacterAnimationParameters;


        protected void Start()
        {
            if (DP!=0)
            {
                HaveDp = true;
            }
            //EventManager.Instance.AddEventListener<CharacterStatus>("造成克制伤害",DpManager.Instance.DPDamage);
            EventManager.Instance.AddEventListener<CharacterStatus>("造成克制伤害",DPDamageTest);
        }

        //调用父类，执行子类
        public virtual void Death() 
        {
            GetComponentInChildren<Animator>().SetBool(CharacterAnimationParameters.dead,true);
        }
        
        protected void Update()
        {

        }
        public void breakDown(float time)
        {
            StartCoroutine(Break_Coroutine(time));
        }
        
        public IEnumerator Break_Coroutine(float time)
        {
            HaveDp = false;
            yield return new WaitForSeconds(time);
            HaveDp = true;
            DP = MAXDP;
        } 
        
        public void DPDamageTest(CharacterStatus characterStatus) 
        {
            Debug.Log("111");
            if (characterStatus.DP>1)
            {
                characterStatus.DP -= 1;
            }
            else
            {
                if (characterStatus.DP==1&&characterStatus.HaveDp)
                {
                    characterStatus.breakDown(3f);
                }
            }
        }
    }
}
