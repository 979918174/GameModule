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
        public float LifeTimer;
        public float upSpeed;

        private void Start()
        {
            Destroy(gameObject,LifeTimer);
        }

        private void Update()
        {
            transform.position += new Vector3(0,upSpeed*Time.deltaTime,0);
        }

        public void ShowUIDamage(float _amount)
        {
            textMeshPro.SetText(_amount.ToString());
        }
    }
}
