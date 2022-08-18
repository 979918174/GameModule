using System;
using System.Collections;
using System.Collections.Generic;
using GameDemo.Character;
using UnityEngine;
using GameDemo.FSM;
using GameDemo.Skill;

namespace Common
{
    /// <summary>
    /// �����¼���Ϊ��
    /// </summary>
    public class AnimatorEventBehaviour : MonoBehaviour
    {
        //�ű������߻�
        //Ϊ����Ƭ������¼���ָ��OnAttack
        
        //����
        //�ڽű��в��Ŷ�������������Ҫִ���߼���ע��
        public event Action attackHandler;
        private Animator anim;
        public CharacterInputController _characterInputController;

       

        private void Start()
        {
            if (GetComponentInParent<PlayerStatus>())
            {
                _characterInputController = GetComponentInParent<Transform>().GetComponentInParent<CharacterInputController>();
            }
            anim = GetComponent<Animator>();
        }
    
        //�����¼�
        void OnAttack(int skillIndex)
        {
            //ǰҡ��־ΪT
            //���켼��
            GetComponentInParent<CharacterSkillSystem>().AttackUseSkill(skillIndex);
        }

        void OnChangeSpeed() 
        {
            anim.SetFloat("attackedSpeed", 1f);
            if (GetComponentInParent<EnemyStatus>())
            {
                GetComponentInParent<EnemyStatus>().passFristAttacked = true;
            }
        }
        void OnCancelAnim(string animParam)
        {
            anim.SetBool(animParam,false);
            /*if (animParam == "attack01"|| animParam == "attack02")
            {
                GetComponentInParent<CharacterInputController>().inputActions.Player.Movement.started += _characterInputController.MovementOnstarted;
                GetComponentInParent<CharacterInputController>().inputActions.Player.Movement.performed += _characterInputController.MovementOnperformed;
                GetComponentInParent<CharacterInputController>().inputActions.Player.Movement.canceled += _characterInputController.MovementOncanceled;
            }*/
            if (animParam == "attacked")
            {
                GetComponentInParent<CharacterStatus>().T_AnimaEnd_Attacked = true;
                GetComponentInParent<CharacterStatus>().passFristAttacked = false;
            }
            if (animParam == "attack01" || animParam == "attack02")
            {
                GetComponentInParent<CharacterStatus>().T_AnimaEnd_Attack01 = true;
            }
        }
    }
}
