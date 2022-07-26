using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Common
{
    /// <summary>
    /// 
    /// </summary>
    public class DamageFloat : MonoBehaviour
    {

        public TextMeshProUGUI textMeshPro;
        public RectTransform rectTrans;
        public Transform WorldTransform;
        public Vector2 screenPos;
        public float LifeTimer;

        private void Start()
        {
            Destroy(gameObject, LifeTimer);       
        }

        private void Update()
        {
            if (WorldTransform != null) 
            {
                
                screenPos = Camera.main.WorldToScreenPoint(WorldTransform.position);
                textMeshPro.rectTransform.position = screenPos;
            }
        }

        public void ShowUIDamage(float _amount)
        {
            textMeshPro.SetText(_amount.ToString());
        }
    }
}
