using System;
using System.Collections;
using System.Collections.Generic;
using Common;
using GameDemo.Skill;
using UnityEngine;
using Sirenix.Serialization;
using Sirenix.OdinInspector;

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
        [Tooltip("����")]
        public int SP;
        [Tooltip("��ǰ����ֵ")]
        public int DP;
        [Tooltip("��󻤶�ֵ")]
        public int MAXDP;
        [Tooltip("����")]
        public TypeID type;
        [Tooltip("��ת�ٶ�")]
        public float rotateSpeed;
        [Tooltip("�ƶ��ٶ�")]
        public float moveSpeed;
        [Tooltip("�ܻ�ʱ��")]

        //��������ж�ֵ
        public bool passFristAttacked;
        [Tooltip("�Ƿ��״��ܻ�")]
        public float hurtTime;
        [Tooltip("�Ƿ��ܻ�")]
        public bool IsHurt;
        [Tooltip("�ܻ��Ƿ����")]
        public bool T_AnimaEnd_Attacked;
        [Tooltip("�Ƿ��л���")] 
        public bool HaveDp;
        public CharacterAnimationParameter CharacterAnimationParameters;

        [ShowInInspector]
        public Dictionary<string, IEventInfo> actionDic;

        protected void Start()
        {
            if (DP!=0)
            {
                HaveDp = true;
            }
            //EventManager.Instance.AddEventListener<CharacterStatus>("��ɿ����˺�",DpManager.Instance.DPDamage);
            actionDic = EventManager.Instance.actionDic;


        }

        //���ø��ִ࣬������
        public virtual void Death() 
        {
            GetComponentInChildren<Animator>().SetBool(CharacterAnimationParameters.dead,true);
        }
        
        protected void Update()
        {

        }
        public void breakDown(float time)
        {
            StartCoroutine(Break_Coroutine(time));
        }
        
        public IEnumerator Break_Coroutine(float time)
        {
            HaveDp = false;
            yield return new WaitForSeconds(time);
            HaveDp = true;
            DP = MAXDP;
        } 
        
        public void DPDamageTest(CharacterStatus characterStatus) 
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
