using System.Collections;
using System.Collections.Generic;
using Logic;
using Sirenix.OdinInspector;
using UnityEngine;
[CreateAssetMenu]
public class SkillConfig : SerializedScriptableObject
{
    public string skillName;
    public string skillDesc;
    public Sprite skillIcon;
    public SkillType SkillType;
    public double skillCoolDown;
    public Dictionary<string,string> skillCondition;
    public GameObject skillScript;
}