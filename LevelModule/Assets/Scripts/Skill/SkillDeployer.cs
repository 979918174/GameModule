using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameDemo.Skill
{
    /// <summary>
    /// �����ͷ���
    /// </summary>
    public class SkillDeployer : MonoBehaviour
    {
        private SkillData skillData;
        public SkillData SkillData 
        {
            get 
            {
                return skillData;
            }
            set 
            {
                skillData = value;
            }
        }

        //ѡ���㷨����
        //private IAttackSelector selector;
        //Ч���㷨����
        //private IImpactEffect[] impactArray;
        //�����㷨����
        private void InitDeplopyer() 
        { 

            //ѡȡ
          
            //Ӱ��
        }
        public void CalculateTargets() 
        { 
        }
        public void ImpactTargets() 
        { 
        }
        //ִ���㷨����

        //�ͷŷ�ʽ
    }
}
