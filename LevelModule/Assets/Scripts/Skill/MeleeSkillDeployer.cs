using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDemo.Skill
{
    /// <summary>
    /// 
    /// </summary>
    public class MeleeSkillDeployer : SkillDeployer
    {
        public override void DeployerSkill()
        {
            transform.SetParent(SkillData.owner.transform);
            CalculateTargets();
            ImpactTargets();
        }
    }
}

