using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDemo.Character
{
    /// <summary>
    /// 玩家状态类
    /// </summary>
    public class EnemyStatus : CharacterStatus
    {
        public override void Death()
        {
            base.Death();
            //定时销毁物体(溶解时间)
            Destroy(gameObject, 2f);
        }
    }
}
