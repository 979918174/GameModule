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
        public string attack01 = "attack01";
        public string attack02 = "attack02";
        public string attack03 = "attack03";
        public string attacked = "attacked";
        public string idle = "idle";
        public string breakdown = "breakdown";
    }
}
