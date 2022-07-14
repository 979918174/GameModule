using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDemo.Character;
namespace GameDemo.Skill
{
    /// <summary>
    /// ÉËº¦Ð§¹û
    /// </summary>
    public class DamageImpact : IImpactEffect
    {
        public void Execute(SkillDeployer deployer)
        {
            foreach (var Target in deployer.SkillData.attackTargets)
            {
                Target.GetComponent<CharacterStatus>().HP
            }
        }
    }

}
