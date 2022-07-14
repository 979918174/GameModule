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
            deployer.StartCoroutine(RepeatDamage(deployer));
        }
        //�ظ��˺�
        private IEnumerator RepeatDamage(SkillDeployer deployer)
        {
            float atkTime = 0;
            do
            {
                
                OnceDamage();
                yield return new WaitForSeconds(data.atkInterval);
                atkTime += data.atkInterval;
                deployer.CalculateTargets();//���¼���ģ��
             } while (atkTime < data.durationTime);
        }
        //�����˺�
        private void OnceDamage()
        {
            //�˺�ֵ ����ϵ��*������
            float damage = data.atkRatio * data.owner.GetComponent<CharacterStatus>().ATK;
            for (int i = 0; i < data.attackTargets.Length; i++)
            {
                
                var status = data.attackTargets[i].GetComponent<CharacterStatus>();
                Animator anim = data.attackTargets[i].GetComponentInChildren<Animator>();
                anim.SetBool(status.CharacterAnimationParameters.attacked,true);
                status.HP -= damage;
            }
        }
    }
}
