using System.Collections;
using System.Collections.Generic;
using Common;
using UnityEngine;
using GameDemo.Character;
using TMPro;
using Unity.Mathematics;
using UnityEngine.UI;
using Cinemachine; 

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
                    //护盾伤害
                    status.DP -= 1;
                    //受击动画
                    Animator anim = data.attackTargets[i].GetComponentInChildren<Animator>();
                    anim.SetBool(status.CharacterAnimationParameters.attacked,true);
                    //伤害
                    status.HP -= damage*2;
                    //飘字
                    DamageFloat damageFloat = GameObject.Instantiate(data.owner.GetComponentInParent<PlayerManager>().damageCanva_weak,
                    data.attackTargets[i].transform.position+new Vector3(UnityEngine.Random.Range(-0.5f,0.5f), UnityEngine.Random.Range(-0.5f, 0.5f), UnityEngine.Random.Range(-0.5f, 0.5f)), quaternion.identity, data.attackTargets[i]).GetComponent<DamageFloat>();
                    damageFloat.ShowUIDamage(damage*2);
                }
                else
                {
                    if (status.type == data.sesistanceType)
                    {
                        Animator anim = data.attackTargets[i].GetComponentInChildren<Animator>();
                        anim.SetBool(status.CharacterAnimationParameters.attacked,true);
                        status.HP -= damage/2;
                        //飘字
                        DamageFloat damageFloat = GameObject.Instantiate(data.owner.GetComponentInParent<PlayerManager>().damageCanva_sesistance,
                        data.attackTargets[i].transform.position + new Vector3(UnityEngine.Random.Range(-0.5f, 0.5f), UnityEngine.Random.Range(-0.5f, 0.5f), UnityEngine.Random.Range(-0.5f, 0.5f)), quaternion.identity, data.attackTargets[i]).GetComponent<DamageFloat>();
                        damageFloat.ShowUIDamage(damage / 2);

                    }
                    else
                    {
                        Animator anim = data.attackTargets[i].GetComponentInChildren<Animator>();
                        anim.SetBool(status.CharacterAnimationParameters.attacked,true);
                        status.HP -= damage;
                        //飘字
                        DamageFloat damageFloat = GameObject.Instantiate(data.owner.GetComponentInParent<PlayerManager>().damageCanva_normal,
                        data.attackTargets[i].transform.position + new Vector3(UnityEngine.Random.Range(-0.5f, 0.5f), UnityEngine.Random.Range(-0.5f, 0.5f), UnityEngine.Random.Range(-0.5f, 0.5f)), quaternion.identity, data.attackTargets[i]).GetComponent<DamageFloat>();
                        damageFloat.ShowUIDamage(damage);

                    }
                    

                }
                //震屏
                data.owner.GetComponentInParent<CinemachineImpulseSource>().GenerateImpulse();




                //GameObject floatPoint = data.attackTargets[i].Find("floatPoint").gameObject;
            }
        }
    }
}
