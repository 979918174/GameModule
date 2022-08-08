using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using GameDemo.Character;
using UnityEngine;
namespace GameDemo.Skill
{
    /// <summary>
    /// 技能管理器:技能释放之前的事情
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
        public SkillData[] skillDatas = new SkillData[3];
        
        //初始化
        /// <summary>
        /// 资源映射表（代码生成）
        /// 资源名称         资源完整路径
        /// </summary>
        private void InitSkill(SkillData data)
        {
            data.skillprefab = ResourceManager.Load<GameObject>(data.prefabName);
            data.owner = gameObject;
        }

        //技能释放条件：冷却
        public SkillData PrePareSkill(int id)
        {
            //根据id查找技能
            SkillData data = ArrayHelper.Find(skillDatas, s => s.skillID == id);
            //判断条件(不为空&&冷却)
            int sp = GetComponent<CharacterStatus>().SP;
            Debug.Log(data.coolDownRemain);
            //返回技能数据
            if (data!=null&&data.coolDownRemain<=1&&data.costSP<=sp)
            {
                return data;
            }
            else
            {
                return null; 
            }
        }

        //生成技能
        public void GenerateSkill(SkillData data)
        {
            //创建技能
            GameObject skillGo = GameObjectPool.Instance.CreateObject(data.prefabName, data.skillprefab, transform.position, transform.rotation);
            SkillDeployer skillDeployer = skillGo.GetComponent<SkillDeployer>();
            //传递技能数据
            skillDeployer.SkillData = data; //内部创建算法对象
            skillDeployer.DeployerSkill();//内部执行算法对象  
            //销毁技能
            GameObjectPool.Instance.CollectObject(skillGo,data.durationTime);
            //Destroy(skillGo,10);
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
