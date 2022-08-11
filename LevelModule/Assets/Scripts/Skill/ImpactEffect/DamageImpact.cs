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
                //����������˺���
                EventManager.Instance.TriggerEventListener<FSM.FSMBase>("����˺�", data.attackTargets[i].GetComponent<FSM.FSMBase>());
                //todo ���������˺�

                var status = data.attackTargets[i].GetComponent<CharacterStatus>();
                if (status.type == data.weakType)
                {
                    //��������ɿ����˺���
                    EventManager.Instance.TriggerEventListener<CharacterStatus>("��ɿ����˺�", data.attackTargets[i].GetComponent<CharacterStatus>());
                    //�ܻ�����
                    //�˺�
                    status.HP -= damage*2;
                    //Ʈ��
                    DamageFloat damageFloat = GameObject.Instantiate(data.owner.GetComponentInParent<PlayerManager>().damageCanva_weak,
                    data.attackTargets[i].transform.position+new Vector3(UnityEngine.Random.Range(-0.5f,0.5f), UnityEngine.Random.Range(-0.5f, 0.5f), UnityEngine.Random.Range(-0.5f, 0.5f)), quaternion.identity, data.attackTargets[i]).GetComponent<DamageFloat>();
                    damageFloat.ShowUIDamage(damage*2);
                }
                else
                {
                    if (status.type == data.sesistanceType)
                    {
                        status.HP -= damage/2;
                        //Ʈ��
                        DamageFloat damageFloat = GameObject.Instantiate(data.owner.GetComponentInParent<PlayerManager>().damageCanva_sesistance,
                        data.attackTargets[i].transform.position + new Vector3(UnityEngine.Random.Range(-0.5f, 0.5f), UnityEngine.Random.Range(-0.5f, 0.5f), UnityEngine.Random.Range(-0.5f, 0.5f)), quaternion.identity, data.attackTargets[i]).GetComponent<DamageFloat>();
                        damageFloat.ShowUIDamage(damage / 2);

                    }
                    else
                    {
                        status.HP -= damage;
                        //Ʈ��
                        DamageFloat damageFloat = GameObject.Instantiate(data.owner.GetComponentInParent<PlayerManager>().damageCanva_normal,
                        data.attackTargets[i].transform.position + new Vector3(UnityEngine.Random.Range(-0.5f, 0.5f), UnityEngine.Random.Range(-0.5f, 0.5f), UnityEngine.Random.Range(-0.5f, 0.5f)), quaternion.identity, data.attackTargets[i]).GetComponent<DamageFloat>();
                        damageFloat.ShowUIDamage(damage);
                    }
                }
                status.IsHurt = true;
                //status.IsHurt = false;
                //����
                data.owner.GetComponentInParent<CinemachineImpulseSource>().GenerateImpulse();
                //GameObject floatPoint = data.attackTargets[i].Find("floatPoint").gameObject;
            }
        }
    }
}
