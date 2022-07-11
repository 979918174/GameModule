using System.Collections;
using System.Collections.Generic;
using Logic;
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
    
    /// <summary>冷却剩余</summary>
    public int coolDownRemain;

    /// <summary>技能预制对象</summary>
    public GameObject skillScript;
    
    /// <summary>技能类型</summary>
}