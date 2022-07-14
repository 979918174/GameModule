using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDemo.Character
{
    /// <summary>
    /// 动画参数
    /// </summary>
    [Serializable]
    public class CharacterAnimationParameter
    {
        public string run = "run";
        public string dead = "dead";
        public string walk = "walk";
        public string attack01 = "T_attack01";
        public string attack02 = "T_attack02";
        public string attack03 = "T_attack03";
        public string attacked = "attacked";
    }
}
