using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameDemo.Skill
{
    /// <summary>
    /// 技能管理器
    /// </summary>
    public class CharacterSkillManager : MonoBehaviour
    {
        private void Start()
        {
            for (int i = 0; i < skillDatas.Length; i++)
            {
                InitSkill(skillDatas[i]);
            }
        }

        //技能列表
        public SkillData[] skillDatas;
        
        //初始化
        private void InitSkill(SkillData data)
        {
            data.skillConfig = Resources.Load<SkillConfig>("Skill" + data.skillConfig);
            data.skillScript = data.skillConfig.skillScript;
            data.owner = gameObject;
        }

        //技能释放条件：冷却
        public SkillData PrePareSkill(int id)
        {
            //根据id查找技能
            //判断条件(不为空&&冷却)
            //返回技能数据
            return null;
        }

        //生成技能
        public void GenerateSkill(SkillData data)
        {
            //创建技能
            GameObject skillGo = Instantiate(data.skillScript, transform.position, transform.rotation);
            //销毁技能
            Destroy(skillGo,10);
            //开启技能冷却
            StartCoroutine(CoolTimeDown(data));
        }

        //技能冷却
        private IEnumerator CoolTimeDown(SkillData data)
        {
            data.coolDownRemain = data.skillCoolDown;
            while (data.coolDownRemain>0)
            {
                yield return new WaitForSeconds(1);
                data.coolDownRemain--;
            }
            
        }
    }
}
