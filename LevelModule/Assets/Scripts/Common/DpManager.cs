using System.Collections;
using GameDemo.Character;
using System.Collections.Generic;
using UnityEngine;
using System;
using GameDemo.Event;
using GameDemo.Skill;

namespace Common
{

    public class DpManager:MonoSingleton<DpManager>
    {
        public void Awake()
        {
            EventCenter.AddListener<GameObject, Transform, SkillData>(EventType.Event_Damage, DPDamage);
        }
        public override void Init()
        {
            base.Init();
        }
        public void DPDamage(GameObject self, Transform target, SkillData data) 
        {
            CharacterStatus targetStatus = target.GetComponent<CharacterStatus>();
            if (targetStatus.DP>1)
            {
                targetStatus.DP -= 1;
            }
            else
            {
                if (targetStatus.DP==1&& targetStatus.HaveDp)
                {
                    targetStatus.DP -= 1;
                    targetStatus.breakDown(4f);
                }
            }
        }
    }
}