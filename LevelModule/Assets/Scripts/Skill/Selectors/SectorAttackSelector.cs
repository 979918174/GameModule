using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using System.Linq;

namespace GameDemo.Skill
{
    /// <summary>
    /// ���Ρ�Բ��ѡ��
    /// </summary>
    public class SectorAttackSelector : IAttackSelector
    {
        public Transform[] SelectTarget(SkillData data, Transform skillTF)
        {
            List<Transform> targets = new List<Transform>();
            //��ȡ����Ŀ��
            for (int i = 0; i < data.attackTargetTags.Length; i++)
            {
                GameObject[] tempGoArray = GameObject.FindGameObjectsWithTag(data.attackTargetTags[i]);
                targets.AddRange(ArrayHelper.Select(tempGoArray, g => g.transform));
            }
            
            //�жϹ�����Χ
             targets = ArrayHelper.FindAll<Transform>(targets, t =>
             Vector3.Distance(t.position, skillTF.position) <= data.attackDistance && 
             Vector3.Angle(skillTF.forward, t.position - skillTF.position) <= data.attackAngle / 2
             );
         
            //ɸѡ����Ľ�ɫ
            //����Ŀ�꣨����/Ⱥ����
            
        }
    }

}
