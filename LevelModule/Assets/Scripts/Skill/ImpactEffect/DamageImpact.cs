using System.Collections;
using System.Collections.Generic;
using Common;
using UnityEngine;
using GameDemo.Character;
using TMPro;
using Unity.Mathematics;
using UnityEngine.UI;
using Cinemachine;
using System;
using GameDemo.Character;
using GameDemo.Event;

namespace GameDemo.Skill
{
    /// <summary>
    /// 伤害效果
    /// </summary>
    public class DamageImpact : IImpactEffect
    {
 
        private SkillData data;
        public void Execute(SkillDeployer deployer)
        {
            data = deployer.SkillData;
            deployer.StartCoroutine(RepeatDamage(deployer));
        }
        //重复伤害
        private IEnumerator RepeatDamage(SkillDeployer deployer)
        {
            float atkTime = 0;
            do
            {
                OnceDamage();
                yield return new WaitForSeconds(data.atkInterval);
                atkTime += data.atkInterval;
                deployer.CalculateTargets();//重新计算模板
             } while (atkTime < data.durationTime);
        }
        //单次伤害
        private void OnceDamage()
        {
            for (int i = 0; i < data.attackTargets.Length; i++)
            {
                //触发“造成伤害”(施法者,受击者,技能数据)
                EventCenter.Broadcast(EventType.Event_Damage, data.owner, data.attackTargets[i],data);
            }
            
        }
    }
}
