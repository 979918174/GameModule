using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDemo.Character;
namespace GameDemo.Skill
{
    /// <summary>
    /// 伤害效果
    /// </summary>
    public class DamageImpact : IImpactEffect
    {
        private SkillData data;
        public void Execute(SkillDeployer deployer)
        {
            data = deployer.SkillData;
            deployer.StartCoroutine(RepeatDamage(deployer));
        }
        //重复伤害
        private IEnumerator RepeatDamage(SkillDeployer deployer)
        {
            float atkTime = 0;
            do
            {
                
                OnceDamage();
                yield return new WaitForSeconds(data.atkInterval);
                atkTime += data.atkInterval;
                deployer.CalculateTargets();//重新计算模板
             } while (atkTime < data.durationTime);
        }
        //单次伤害
        private void OnceDamage()
        {
            //伤害值 技能系数*攻击力
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
