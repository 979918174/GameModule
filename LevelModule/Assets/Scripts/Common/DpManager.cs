using System.Collections;
using GameDemo.Character;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Common
{

    public class DpManager
    {
        private static DpManager instance;

        public static DpManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DpManager();
                }

                return instance;
            }
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