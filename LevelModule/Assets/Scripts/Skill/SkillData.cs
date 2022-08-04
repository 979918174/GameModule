using System;
using System.Collections;
using System.Collections.Generic;
using Common;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameDemo.Skill
{
    /// <summary>
    /// 技能数据类
    /// </summary>
    [Serializable]
    public class SkillData
    {
        
        /// <summary>技能ID</summary>
      
        public int skillID;

        /// <summary>技能配置</summary>
        public SkillConfig skillConfig;
        
        /// <summary>技能名字</summary>
        public string skillName;
    
        /// <summary>技能描述</summary>
        public string skillDesc;

        /// <summary>技能冷却</summary>
        public int skillCoolDown;
    
        /// <summary>冷却剩余</summary>
        public int coolDownRemain;
        
        /// <summary>攻击距离</summary>
        public float attackDistance;
        
        /// <summary>攻击角度</summary>
        public float attackAngle;
        
        /// <summary>攻击目标tags</summary>
        public string[] attackTargetTags = {"Enemy"};
        
        /// <summary>攻击目标对象数组</summary>
        public Transform[] attackTargets;
        
        /// <summary>能量消耗</summary>
        public int costSP;

        /// <summary>持续时间</summary>
        public float durationTime;
        
        /// <summary>伤害率</summary>
        public float atkRatio;
        
        /// <summary>伤害间隔</summary>
        public float atkInterval;
    
        /// <summary>技能所属</summary>
        public GameObject owner;

        /// <summary>技能预制对象</summary>
        public GameObject skillprefab;

        /// <summary>技能预制对象名字</summary>
        public string prefabName;

        /// <summary>选择类型</summary>
        public SelectorType selectorType;
        
        /// <summary>技能效果类型</summary>
        public string[] impactType = {"Damage"};

        /// <summary>受击效果预制体</summary>
        public string hitFXName;
        
        /// <summary>攻击类型（单攻、群攻）</summary>
        public SkillAttackType attackType;
        
        ////// <summary>技能动画</summary>
        public string animationName;
        
        ////// <summary>技能属性</summary>
        public TypeID skillType;
        
        ////// <summary>克制属性</summary>
        public TypeID weakType;
        
        ////// <summary>抵抗属性</summary>
        public TypeID  sesistanceType;
        
        ////// <summary>技能关键帧</summary>
        public float skillPreFrame;
        
        ////// <summary>技能结束帧</summary>
        public float skillEndFrame;
    }
}
