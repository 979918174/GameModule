using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDemo.Character
{
    /// <summary>
    /// ��ɫ״̬��
    /// </summary>
    public class CharacterStatus : MonoBehaviour
    {
        [Tooltip("��ǰѪ��")]
        public float HP;
        [Tooltip("���Ѫ��")]
        public float MAXHP;
        [Tooltip("������")]
        public float ATK;
        [Tooltip("��ǰ����ֵ")]
        public int GP;
        [Tooltip("��󻤶�ֵ")]
        public float MAXGP;
        [Tooltip("����")]
        public Logic.Type type;

        public CharacterAnimationParameter CharacterAnimationParameters;
        public void Damage() 
        {
        
        }

        //���ø��ִ࣬������
        public virtual void Death() 
        {
        
        }
    }
}
