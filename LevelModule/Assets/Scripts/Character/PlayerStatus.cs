using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDemo.Character
{
    /// <summary>
    /// 玩家状态类
    /// </summary>
    public class PlayerStatus : CharacterStatus
    {
        public override void Death()
        {
            base.Death();
            //判断否调用交换 
            if (GetComponentInParent<PlayerManager>().MyCharacters.Count>1)
            {
                GetComponentInParent<PlayerManager>().ChangeCharacterDown();
            }
            else
            {
                Debug.Log("gameover");
            }
            GetComponentInParent<PlayerManager>().MyCharacters.Remove(gameObject);
            Destroy(gameObject,2f);
           
        }
    }
}
