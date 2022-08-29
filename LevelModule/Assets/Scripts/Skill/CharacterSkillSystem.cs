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
        private CharacterMotor characterMotor;
        public Transform targetTF = null;
        [Tooltip("攻击目标标签")]
        public string[] targetTags = { "Enemy" };

        private CharacterStatus _characterStatus;
        private void Start()
        {
            _characterSkillManager = GetComponent<CharacterSkillManager>();
            anim = GetComponentInChildren<Animator>();
            _characterStatus = GetComponent<CharacterStatus>();
            characterMotor = GetComponent<CharacterMotor>();
        }

        private SkillData skill;

        public void AttackUseSkill(int index)
        {
            //准备技能
            skill = _characterSkillManager.PrePareSkill(index);
            if (skill == null) return;
           /* if (GetComponent<PlayerStatus>())
            {
                //方向修正,先转向再播动画，线性插值
                //朝向，距离，打不到再修
                if (true)
                {
                    SkillData data = new SkillData()
                    {
                        attackTargetTags = targetTags,
                        attackDistance = 100,
                        attackAngle = 360,
                        attackType = SkillAttackType.Group
                    };
                    Transform[] targetArr = new SectorAttackSelector().SelectTarget(data, transform);
                    targetTF = targetArr.Length == 0 ? null : targetArr[0];
                    if (targetTF)
                    {
                        transform.rotation = Quaternion.LookRotation(targetTF.position-transform.position);
                    }
                }
            }*/
            //生成技能
            _characterSkillManager.GenerateSkill(skill);
            //StartCoroutine(SkillPreAnim(skill));
        }

        public void UseRandomSkill()
        {
            
        }
/*
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
        }*/
    }
}
