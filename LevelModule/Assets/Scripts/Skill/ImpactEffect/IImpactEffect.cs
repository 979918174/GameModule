using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDemo.Skill
{
    /// <summary>
    /// Ӱ���㷨
    /// </summary>
    public interface IImpactEffect
    {
        //�˺�����
        void Execute(SkillDeployer deployer);
    }
}
