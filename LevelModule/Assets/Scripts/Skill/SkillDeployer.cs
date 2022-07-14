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
            }
        }
        private IAttackSelector _selector;
        private IImpactEffect[] _impactEffects;

        //选区算法对象
        //private IAttackSelector selector;
        //效果算法对象
        //private IImpactEffect[] impactArray;
        //创建算法对象
        private void InitDeplopyer()
        {
            _selector = DeployerConfigFactory.CreateAttackSelector(skillData);
            //DeployerConfigFactory.CreateImpactEffect(skillData);
        }
        //执行选区
        public void CalculateTargets() 
        {
            InitDeplopyer();
            skillData.attackTargets = _selector.SelectTarget(skillData, transform);
            foreach (var item in skillData.attackTargets)
            {
                print(item);
            }
        }
        public void ImpactTargets() 
        { 
        }
        //执行算法对象

        //释放方式
        public abstract void DeployerSkill();
    }
}
