using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using GameDemo.Skill;
using GameDemo.Character;
using GameDemo.Event;
using Cinemachine;

public class DamageManage : MonoSingleton<DamageManage>
{
    public GameObject damageCanva_weak;
    public GameObject damageCanva_normal;
    public GameObject damageCanva_sesistance;
    public CinemachineImpulseSource cinemachineImpulseSource;
    public float timescale;
    public void Awake()
    {
        EventCenter.AddListener<GameObject, Transform, SkillData>(EventType.Event_Damage, ApplyDamage);
    }
    public float CalDamage(GameObject self, Transform target, SkillData data) 
    {
        float damage = data.atkRatio * data.owner.GetComponent<CharacterStatus>().ATK;
        CharacterStatus targetStatus = target.GetComponent<CharacterStatus>();
        if (targetStatus.type == data.weakType)
        {
            damage *= 2;
            //Æ®×Ö
            FloatDamage(target, damage, damageCanva_weak);
            
        }
        else
        {
            if (targetStatus.type == data.sesistanceType)
            {
                damage /= 2;
                //Æ®×Ö
                FloatDamage(target, damage, damageCanva_sesistance);
            }
            else
            {
                FloatDamage(target, damage, damageCanva_normal);
            }
        }
        return damage;
    }

    public void ApplyDamage(GameObject self,Transform target,SkillData data) 
    {
        CharacterStatus selfStatus = self.GetComponent<CharacterStatus>();
        CharacterStatus targetStatus = target.GetComponent<CharacterStatus>();
        targetStatus.HP -= CalDamage(self, target, data);
        targetStatus.IsHurt = true;
        //ÕðÆÁ
        cinemachineImpulseSource.GenerateImpulse(4);
        //ÊÜ»÷ÌØÐ§
        Transform trans = target.Find("hitPoint");
        GameObject FX = GameObjectPool.Instance.CreateObject("fx_com_hit", ResourceManager.Load<GameObject>("fx_com_hit"), trans.position, trans.rotation);
        GameObjectPool.Instance.CollectObject(FX, 2f);
        //¶ÙÖ¡
        StartCoroutine(HitTimeScale());
    }

    //Æ®×Ö·´À¡
    public void FloatDamage(Transform target,float damage,GameObject floatPre) 
    {
        DamageFloat damageFloat = GameObject.Instantiate(floatPre,
        target.position+new Vector3(UnityEngine.Random.Range(-0.5f,0.5f), UnityEngine.Random.Range(-0.5f, 0.5f), UnityEngine.Random.Range(-0.5f, 0.5f)), 
        Quaternion.identity, target).GetComponent<DamageFloat>();
        damageFloat.ShowUIDamage(damage);
    }

    IEnumerator HitTimeScale()
    {
        Time.timeScale = timescale;
        yield return new WaitForSeconds(0.05f);
        Time.timeScale = 1;
    }
}
