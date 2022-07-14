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
    public class SkillDeployer : MonoBehaviour
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
            DeployerConfigFactory.CreateAttackSelector(skillData);
            DeployerConfigFactory.CreateImpactEffect(skillData);
        }
        public void CalculateTargets() 
        { 

        }
        public void ImpactTargets() 
        { 
        }
        //执行算法对象

        //释放方式
    }
}
