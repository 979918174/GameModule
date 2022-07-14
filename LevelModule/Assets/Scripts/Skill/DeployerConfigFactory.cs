using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDemo.Skill
{
    /// <summary>
    /// 释放器配置工厂
    /// </summary>
    public class DeployerConfigFactory 
    {
        public static IAttackSelector CreateAttackSelector(SkillData data)
        {
            string className = string.Format("GameDemo.Skill.{0}AttackSelector", data.selectorType);
            //选取
            Debug.Log(className);
            return CreateObject<IAttackSelector>(className);

        }
        
        public static IImpactEffect[] CreateImpactEffect(SkillData data)
        {
            IImpactEffect[] _impactEffects = new IImpactEffect[data.impactType.Length];
            for (int i = 0; i < data.impactType.Length; i++)
            {
                string classNameImpact = string.Format("GameDemo.Skill.{0}Impact", data.impactType[i]);
                _impactEffects[i] = CreateObject<IImpactEffect>(classNameImpact);
            }
            return _impactEffects;

        }
        private static T CreateObject<T>(string className) where T:class
        {
            Type type = Type.GetType(className);
            return Activator.CreateInstance(type) as T;
        }

    }
}
