using System;
using System.Collections;
using System.Collections.Generic;
using GameDemo.Character;
using UnityEngine;
using GameDemo.FSM;

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
        private InputAction_1 inputActions;
        public CharacterInputController _characterInputController;

       

        private void Start()
        {
            anim = GetComponent<Animator>();
            //inputActions = GetComponentInParent<CharacterInputController>().inputActions;
            //_characterInputController = GetComponentInParent<Transform>().GetComponentInParent<CharacterInputController>();
        }
    
        //�����¼�
        void OnAttack()
        {
            if (attackHandler != null)
            {
                attackHandler();
            }
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
                if (GetComponentInParent<EnemyStatus>())
                {
                    GetComponentInParent<EnemyStatus>().T_AnimaEnd_Attacked = true;
                    GetComponentInParent<EnemyStatus>().passFristAttacked = false;
                }
            }
        }
    }
}
