using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using Random = System.Random;

namespace GameDemo.Skill
{
    [RequireComponent(typeof(CharacterSkillManager))]
    /// <summary>
    /// 封装技能系统，提供简单的技能释放功能
    /// </summary>
    public class CharacterSkillSystem : MonoBehaviour
    {

        private CharacterSkillManager _characterSkillManager;
        private void Start()
        {
            _characterSkillManager = GetComponent<CharacterSkillManager>();
        }

        //准备技能
        //播放动画
        //生成技能
        public void AttackUseSkill(int skillID)
        {
        }

        public void UseRandomSkill()
        {
            
        }
    }
}
