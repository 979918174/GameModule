using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDemo.Character;
using UnityEngine.InputSystem;
using GameDemo.Skill;
using Common;
using DG.Tweening;


namespace GameDemo.FSM
{
    public class Attacking_StandState : FSMState
    {
        public Transform targetTF = null;
        [Tooltip("攻击目标标签")]
        public string[] targetTags = { "Enemy" };
        public override void Init()
        {
            StateID = FSMStateID.Attacking_Stand;
        }

        public override void EnterState(FSMBase fsm)
        {
            if ((fsm as FSMBase_Player).characterInputController.inputActions.Player.Attack_01.phase == InputActionPhase.Performed ||
                  (fsm as FSMBase_Player).characterInputController.inputActions.Player.Attack_01.phase == InputActionPhase.Started)
            {
                if (fsm.GetComponent<PlayerStatus>())
                {
                    //方向修正,先转向再播动画，线性插值
                    //朝向，距离，打不到再修
                    if (true)
                    {
                        SkillData data = new SkillData()
                        {
                            attackTargetTags = targetTags,
                            attackDistance = 100,
                            attackAngle = 360,
                            attackType = SkillAttackType.Group
                        };
                        Transform[] targetArr = new SectorAttackSelector().SelectTarget(data, fsm.transform);
                        targetTF = targetArr.Length == 0 ? null : targetArr[0];
                        if (targetTF)
                        {
                            fsm.transform.DOLookAt(targetTF.position,0.3f);
                        }
                    }
                }
                fsm.anim.SetBool(fsm.chStatus.CharacterAnimationParameters.attack01, true);
            }
            else
            {
                if ((fsm as FSMBase_Player).characterInputController.inputActions.Player.Attack_02.phase == InputActionPhase.Performed ||
                   (fsm as FSMBase_Player).characterInputController.inputActions.Player.Attack_02.phase == InputActionPhase.Started)
                {
                    if (fsm.GetComponent<PlayerStatus>())
                    {
                        //方向修正,先转向再播动画，线性插值
                        //朝向，距离，打不到再修
                        if (true)
                        {
                            SkillData data = new SkillData()
                            {
                                attackTargetTags = targetTags,
                                attackDistance = 100,
                                attackAngle = 360,
                                attackType = SkillAttackType.Group
                            };
                            Transform[] targetArr = new SectorAttackSelector().SelectTarget(data, fsm.transform);
                            targetTF = targetArr.Length == 0 ? null : targetArr[0];
                            if (targetTF)
                            {
                                fsm.transform.DOLookAt(targetTF.position, 0.3f);
                            }
                        }
                    }
                    fsm.anim.SetBool(fsm.chStatus.CharacterAnimationParameters.attack02, true);
                }
            }
            //修改动画参数（bool）
           
        }

        public override void ExitState(FSMBase fsm)
        {
            //修改动画参数（bool）
            fsm.anim.SetBool(fsm.chStatus.CharacterAnimationParameters.attack01, false);
            fsm.anim.SetBool(fsm.chStatus.CharacterAnimationParameters.attack02, false);
            //
            fsm.chStatus.T_AnimaEnd_Attack01 = false;
            base.ExitState(fsm);
        }
    }
    


}
