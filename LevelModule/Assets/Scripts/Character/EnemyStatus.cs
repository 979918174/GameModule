using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDemo.Character
{
    /// <summary>
    /// ���״̬��
    /// </summary>
    public class EnemyStatus : CharacterStatus
    {
        public override void Death()
        {
            base.Death();
            Destroy(gameObject, 10);
        }
    }
}
