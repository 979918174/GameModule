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
        private Animator anim; 
        private void Start()
        {
            _characterSkillManager = GetComponent<CharacterSkillManager>();
            anim = GetComponentInChildren<Animator>();
            GetComponentInChildren<AnimatorEventBehaviour>().attackHandler += DeploySkill;
        }

        private void DeploySkill()
        {
            _characterSkillManager.GenerateSkill(skill);
        }

        private SkillData skill;

        public void AttackUseSkill(int skillID)
        {
            //准备技能
            skill = _characterSkillManager.PrePareSkill(skillID);
            //播放动画
            if (skill == null) return;
            anim.SetBool(skill.animationName,true);
            //生成技能
        }

        public void UseRandomSkill()
        {
            
        }
    }
}
