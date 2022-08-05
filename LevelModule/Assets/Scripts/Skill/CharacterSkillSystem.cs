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
        private CharacterInputController characterInputController;
        private CharacterStatus _characterStatus;
        private void Start()
        {
            _characterSkillManager = GetComponent<CharacterSkillManager>();
            anim = GetComponentInChildren<Animator>();
            characterInputController = GetComponentInParent<CharacterInputController>();
            _characterStatus = GetComponent<CharacterStatus>();
        }

        private SkillData skill;

        public void AttackUseSkill(int skillID)
        {
            //准备技能
            skill = _characterSkillManager.PrePareSkill(skillID);
            //播放动画
            if (skill == null) return;
            //anim.SetBool(skill.animationName,true);
            //判断攻击前后摇类型 todo
            //生成技能

            StartCoroutine(SkillPreAnim(skill));
            //结束技能
            StartCoroutine(SkillEndAnim(skill));
        }
        //选中的目标
        public Transform selectedTarget;

        private void SetSelectedActiveFx(bool state)
        {
            if (selectedTarget == null) return;
            var selected = selectedTarget.GetComponent<CharacterSelected>();
            if (selected) selected.SetSelectedActive(state);
        }

        private Transform SelectTarget() 
        {
            Transform[] target = new SectorAttackSelector().SelectTarget(skill, transform);
            return target.Length != 0 ? target[0]:null;
        }
        public void UseRandomSkill()
        {
            
        }

        IEnumerator SkillPreAnim(SkillData data) 
        {
            yield return new WaitForSeconds(data.skillPreFrame);
            _characterSkillManager.GenerateSkill(data);
        }
        
        IEnumerator SkillEndAnim(SkillData data) 
        {
            yield return new WaitForSeconds(data.skillEndFrame);
            characterInputController.T_AnimaEnd_Attack01 = true;
            //anim.SetBool(skill.animationName,false);
        }
    }
}
