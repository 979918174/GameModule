﻿using System.Collections;
using GameDemo.Character;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Common
{

    public class DpManager:MonoSingleton<DpManager>
    {
        public override void Init()
        {
            base.Init();
            EventManager.Instance.AddEventListener<CharacterStatus>("造成克制伤害", DPDamage);
        }
        public void DPDamage(CharacterStatus characterStatus) 
        {
            Debug.Log("111");
            if (characterStatus.DP>1)
            {
                characterStatus.DP -= 1;
            }
            else
            {
                if (characterStatus.DP==1&&characterStatus.HaveDp)
                {
                    characterStatus.breakDown(3f);
                }
            }
        }
    }
}