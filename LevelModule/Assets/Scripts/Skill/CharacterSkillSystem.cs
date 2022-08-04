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
        private InputAction_1 inputActions;
        private CharacterStatus _characterStatus;
        private void Start()
        {
            _characterSkillManager = GetComponent<CharacterSkillManager>();
            anim = GetComponentInChildren<Animator>();
            inputActions = GetComponentInParent<CharacterInputController>().inputActions;
            _characterStatus = GetComponent<CharacterStatus>();
        }

        private SkillData skill;

        public void AttackUseSkill(int skillID)
        {
            //todo 注销移动事件,关掉移动动画
            //inputActions.Player.Movement.started -= GetComponentInParent<CharacterInputController>().MovementOnstarted;
            //inputActions.Player.Movement.performed -= GetComponentInParent<CharacterInputController>().MovementOnperformed;
            //inputActions.Player.Movement.canceled -= GetComponentInParent<CharacterInputController>().MovementOncanceled;
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
            //先取消上次选中的物体
            SetSelectedActiveFx(false);
            selectedTarget = targetTF;
            //选中A，在自动取消前，又选中B目标，则手动将A取消
            SetSelectedActiveFx(true);
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
    }
}
