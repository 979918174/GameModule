using System.Collections;
using System.Collections.Generic;
using Common;
using UnityEngine;
using GameDemo.Character;
using TMPro;
using Unity.Mathematics;
using UnityEngine.UI;
using Cinemachine;
using System;
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
                //触发“造成伤害”
                EventManager.Instance.TriggerEventListener<FSM.FSMBase>("造成伤害", data.attackTargets[i].GetComponent<FSM.FSMBase>());
                //todo 修正属性伤害

                var status = data.attackTargets[i].GetComponent<CharacterStatus>();
                if (status.type == data.weakType)
                {
                    //触发“造成克制伤害”
                    EventManager.Instance.TriggerEventListener<CharacterStatus>("造成克制伤害", data.attackTargets[i].GetComponent<CharacterStatus>());
                    //受击动画
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
                        status.HP -= damage/2;
                        //飘字
                        DamageFloat damageFloat = GameObject.Instantiate(data.owner.GetComponentInParent<PlayerManager>().damageCanva_sesistance,
                        data.attackTargets[i].transform.position + new Vector3(UnityEngine.Random.Range(-0.5f, 0.5f), UnityEngine.Random.Range(-0.5f, 0.5f), UnityEngine.Random.Range(-0.5f, 0.5f)), quaternion.identity, data.attackTargets[i]).GetComponent<DamageFloat>();
                        damageFloat.ShowUIDamage(damage / 2);

                    }
                    else
                    {
                        status.HP -= damage;
                        //飘字
                        DamageFloat damageFloat = GameObject.Instantiate(data.owner.GetComponentInParent<PlayerManager>().damageCanva_normal,
                        data.attackTargets[i].transform.position + new Vector3(UnityEngine.Random.Range(-0.5f, 0.5f), UnityEngine.Random.Range(-0.5f, 0.5f), UnityEngine.Random.Range(-0.5f, 0.5f)), quaternion.identity, data.attackTargets[i]).GetComponent<DamageFloat>();
                        damageFloat.ShowUIDamage(damage);
                    }
                }
                status.IsHurt = true;
                //status.IsHurt = false;
                //震屏
                data.owner.GetComponentInParent<CinemachineImpulseSource>().GenerateImpulse();
                //GameObject floatPoint = data.attackTargets[i].Find("floatPoint").gameObject;
            }
        }
    }
}
