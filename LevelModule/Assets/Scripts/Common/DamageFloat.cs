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
        public float LifeTimer;

        private void Start()
        {
            Destroy(gameObject, LifeTimer);       
        }

        private void Update()
        {
          
        }

        public void ShowUIDamage(float _amount)
        {
            GetComponent<TextMeshPro>().SetText(_amount.ToString());
        }
    }
}
