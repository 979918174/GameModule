using System.Collections;
using System.Collections.Generic;
using Common;
using UnityEngine;
using GameDemo.Character;
using TMPro;
using Unity.Mathematics;
using UnityEngine.UI;

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
                //todo 修正属性伤害
               
                var status = data.attackTargets[i].GetComponent<CharacterStatus>();
                if (status.type == data.weakType)
                {
                    status.DP -= 1;
                    Animator anim = data.attackTargets[i].GetComponentInChildren<Animator>();
                    anim.SetBool(status.CharacterAnimationParameters.attacked,true);
                    status.HP -= damage*2;
                    //飘字
                    DamageFloat damageFloat = GameObject.Instantiate(data.owner.GetComponentInParent<PlayerManager>().damageCanva_weak,
                    data.attackTargets[i].transform.position, quaternion.identity, data.attackTargets[i]).GetComponent<DamageFloat>();
                    damageFloat.WorldTransform = data.attackTargets[i];
                    damageFloat.textMeshPro.rectTransform.position = Camera.main.WorldToScreenPoint(data.attackTargets[i].transform.position);
                    damageFloat.ShowUIDamage(damage*2);
                }
                else
                {
                    if (status.type == data.sesistanceType)
                    {
                        Animator anim = data.attackTargets[i].GetComponentInChildren<Animator>();
                        anim.SetBool(status.CharacterAnimationParameters.attacked,true);
                        status.HP -= damage/2;

                        DamageFloat damageFloat = GameObject.Instantiate(data.owner.GetComponentInParent<PlayerManager>().damageCanva_weak,
                        data.attackTargets[i].transform.position, quaternion.identity, data.attackTargets[i]).GetComponent<DamageFloat>();
                        damageFloat.WorldTransform = data.attackTargets[i];
                        damageFloat.textMeshPro.rectTransform.position = Camera.main.WorldToScreenPoint(data.attackTargets[i].transform.position);
                        damageFloat.ShowUIDamage(damage / 2);

                    }
                    else
                    {
                        Animator anim = data.attackTargets[i].GetComponentInChildren<Animator>();
                        anim.SetBool(status.CharacterAnimationParameters.attacked,true);
                        status.HP -= damage;

                        DamageFloat damageFloat = GameObject.Instantiate(data.owner.GetComponentInParent<PlayerManager>().damageCanva_weak,
                        data.attackTargets[i].transform.position, quaternion.identity, data.attackTargets[i]).GetComponent<DamageFloat>();
                        damageFloat.WorldTransform = data.attackTargets[i];
                        damageFloat.textMeshPro.rectTransform.position = Camera.main.WorldToScreenPoint(data.attackTargets[i].transform.position);
                        damageFloat.ShowUIDamage(damage);

                    }
                }
                
                
                
                
                //GameObject floatPoint = data.attackTargets[i].Find("floatPoint").gameObject;
            }
        }
    }
}
