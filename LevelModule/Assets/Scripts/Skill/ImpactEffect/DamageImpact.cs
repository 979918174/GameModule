using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDemo.Character;
namespace GameDemo.Skill
{
    /// <summary>
    /// �˺�Ч��
    /// </summary>
    public class DamageImpact : IImpactEffect
    {
        private SkillData data;
        public void Execute(SkillDeployer deployer)
        {
            data = deployer.SkillData;
            deployer.StartCoroutine(RepeatDamage());
        }
        private IEnumerator RepeatDamage(SkillDeployer deployer)
        {
            float atkTime = 0;
            do
            {
                yield return new WaitForSeconds(data.atkInterval);
                atkTime += data.atkInterval;
                deployer.CalculateTargets();//���¼���ģ��
             } while (atkTime < data.durationTime);
        }
    }
}
