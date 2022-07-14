using System;
using System.Collections;
using System.Collections.Generic;
using Common;
using UnityEngine;
using Type = System.Type;

namespace GameDemo.Skill
{
    /// <summary>
    /// 技能释放器
    /// </summary>
    public abstract class SkillDeployer : MonoBehaviour
    {
        private SkillData skillData;
        public SkillData SkillData 
        {
            get 
            {
                return skillData;
            }
            set 
            {
                skillData = value;
                InitDeplopyer();
            }
        }
        //选区算法对象
        private IAttackSelector _selector;
        //效果算法对象
        private IImpactEffect[] _impactEffects;
        //创建算法对象
        private void InitDeplopyer()
        {
            _selector = DeployerConfigFactory.CreateAttackSelector(skillData);
            _impactEffects = DeployerConfigFactory.CreateImpactEffect(skillData);
        }
        //执行选区
        public void CalculateTargets() 
        {
            skillData.attackTargets = _selector.SelectTarget(skillData, transform);
        }
        //影响目标
        public void ImpactTargets() 
        {
            for (int i = 0; i < _impactEffects.Length; i++)
            {
                _impactEffects[i].Execute(this);
            }
        }
        //执行算法对象

        //释放方式
        public abstract void DeployerSkill();
    }
}
