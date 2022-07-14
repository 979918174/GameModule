using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using System.Linq;
using GameDemo.Character;

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
             targets = ArrayHelper.FindAll_L(targets, t =>
             Vector3.Distance(t.position, skillTF.position) <= data.attackDistance && 
             Vector3.Angle(skillTF.forward, t.position - skillTF.position) <= data.attackAngle / 2
             );

            //筛选出活的角色
             targets = ArrayHelper.FindAll_L(targets, t => t.GetComponent<CharacterStatus>().HP > 0);
            //返回目标（单攻/群攻）
            Transform[] result = targets.ToArray();
            if (data.attackType == SkillAttackType.Group)
                return result;
            Transform min = ArrayHelper.GetMin(result, t => Vector3.Distance(t.position, skillTF.position));
            return new Transform[] { min };

        }
    }

}
