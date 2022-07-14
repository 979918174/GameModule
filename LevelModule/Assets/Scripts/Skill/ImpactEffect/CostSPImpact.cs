using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDemo.Character;

namespace GameDemo.Skill
{
    /// <summary>
    /// ÏûºÄ·¨Á¦
    /// </summary>
    public class CostSPImpact : IImpactEffect
    {
        public void Execute(SkillDeployer deployer)
        {
            var status = deployer.SkillData.owner.GetComponent<CharacterStatus>();
            status.SP -= deployer.SkillData.costSP;
        }
    }

}
