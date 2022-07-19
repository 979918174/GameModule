using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDemo.Character
{
    /// <summary>
    /// ��ɫѡ����
    /// </summary>
    public class CharacterSelected : MonoBehaviour
    {
        public GameObject selectedGO;
        [Tooltip("ѡ������Ϸ��������")]
        public string selectedName = "selected";
        [Tooltip("��ʾʱ��")]
        public float displayTime = 3;
        private void Start()
        {
            selectedGO = transform.Find(selectedName).gameObject;
        }
        private float hideTime;
        public void SetSelectedActive(bool state) 
        {
            //����ѡ�������弤��״̬
            selectedGO.SetActive(state);
            //���õ�ǰ�ű�����״̬(����/ֹͣUpdate����)
            this.enabled = state;
            if (state)
            hideTime = Time.time + displayTime;
        }
        private void Update()
        {
            if (hideTime <= Time.time)
            {
                SetSelectedActive(false);
            }
        }
    }
}

