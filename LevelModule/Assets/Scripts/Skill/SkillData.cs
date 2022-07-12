using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDemo.Skill
{
    /// <summary>
    /// 技能数据类
    /// </summary>
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
    
        /// <summary>技能图标</summary>
        public Sprite skillIcon;
    
        /// <summary>技能冷却</summary>
        public int skillCoolDown;
    
        /// <summary>冷却剩余</summary>
        public int coolDownRemain;
    
        /// <summary>技能所属</summary>
        public GameObject owner;

        /// <summary>技能预制对象</summary>
        public GameObject skillprefab;

        /// <summary>技能预制对象</summary>
        public string prefabName;

    }
}
