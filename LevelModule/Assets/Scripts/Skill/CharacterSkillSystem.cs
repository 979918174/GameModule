using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using Random = System.Random;
using GameDemo.Character;

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
            //单攻
            if (skill.attackType != SkillAttackType.Single) return;
            //查找目标
            Transform targetTF = SelectTarget();
            //转向目标
            transform.LookAt(targetTF);
            //选中目标(特效)
            var selected = targetTF.GetComponent<CharacterSelected>();
            if (selected) selected.SetSelectedActive(true);
        }
        private Transform SelectTarget() 
        {
            Transform[] target = new SectorAttackSelector().SelectTarget(skill, transform);
            return target.Length != 0 ? target[0]:null;
        }
        private void SetSelectedActiveFx(bool state) 
        { 
        
        }
        public void UseRandomSkill()
        {
            
        }
    }
}
