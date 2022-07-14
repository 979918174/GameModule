using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using System.Linq;

namespace GameDemo.Skill
{
    /// <summary>
    /// 扇形、圆形选区
    /// </summary>
    public class SectorAttackSelector : IAttackSelector
    {
        public Transform[] SelectTarget(SkillData data, Transform skillTF)
        {
            List<Transform> targets = new List<Transform>();
            //获取所有目标
            for (int i = 0; i < data.attackTargetTags.Length; i++)
            {
                GameObject[] tempGoArray = GameObject.FindGameObjectsWithTag(data.attackTargetTags[i]);
                targets.AddRange(ArrayHelper.Select(tempGoArray, g => g.transform));
            }
            
            //判断攻击范围
             targets = ArrayHelper.FindAll<Transform>(targets, t =>
             Vector3.Distance(t.position, skillTF.position) <= data.attackDistance && 
             Vector3.Angle(skillTF.forward, t.position - skillTF.position) <= data.attackAngle / 2
             );
         
            //筛选出活的角色
            //返回目标（单攻/群攻）
            
        }
    }

}
