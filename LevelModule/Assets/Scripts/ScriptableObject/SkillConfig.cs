using System.Collections;
using System.Collections.Generic;
using Common;
using GameDemo.Skill;
using Sirenix.OdinInspector;
using UnityEngine;

/// <summary>
/// 技能数据类
/// </summary>
[CreateAssetMenu]
public class SkillConfig : SerializedScriptableObject
{

    /// <summary>技能名字</summary>
    public string skillName;
    /// <summary>技能描述</summary>
    public string skillDesc;
    /// <summary>技能图标</summary>
    public Sprite skillIcon;



    /// <summary>技能冷却</summary>
    public int skillCoolDown;
    /// <summary>技能预制对象</summary>
    public GameObject skillScript;

    /// <summary>技能类型</summary>

    /// <summary>选择器与相关参数</summary>
    /// 攻击距离与攻击角度
    public Dictionary<SelectorType, List<string>> selectorPar;

    /// <summary>攻击目标Tag</summary>
    public string[] attackTargetTags;

    /// <summary>能量消耗</summary>
    public int costSP;

    /// <summary>持续时间</summary>
    public float durationTime;

    /// <summary>伤害率</summary>
    public float atkRatio;

    /// <summary>伤害间隔</summary>
    public float atkInterval;

    /// <summary>技能预制对象名字</summary>
    public string prefabName;

    /// <summary>受击效果预制体</summary>
    public string hitFXName;

    /// <summary>效果类型与相关参数</summary>
    public Dictionary<string, List<string>> effectPar;

    ////// <summary>技能属性</summary>
    public TypeID skillType;

    ////// <summary>克制属性</summary>
    public TypeID weakType;

    ////// <summary>抵抗属性</summary>
    public TypeID sesistanceType;

    ////// <summary>技能关键帧</summary>
    public float skillPreFrame;

    ////// <summary>技能结束帧</summary>
    public float skillEndFrame;
}