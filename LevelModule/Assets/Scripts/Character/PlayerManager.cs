using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Common;
using GameDemo.FSM;

namespace GameDemo.Character
{
    /// <summary>
    /// 
    /// </summary>
    public class PlayerManager : MonoBehaviour
    {
        //public GameObject[] MyCharacters;
        public List<GameObject> MyCharacters;
        public GameObject currentCharacter;
        public GameObject CamaraConfig;
        public int index;
        public FSMBase fsmBase;
        public bool trigger;

        public void Awake()
        {
            MyCharacters.AddRange(GameObject.FindGameObjectsWithTag("Player"));
            currentCharacter = MyCharacters[0];      
            foreach (var character in MyCharacters)
            {
                character.SetActive(false);
            }
            currentCharacter.SetActive(true);
            fsmBase = currentCharacter.GetComponent<FSMBase>();
            index = 0;
            CamaraConfig.GetComponent<CinemachineVirtualCamera>().m_Follow = currentCharacter.transform;
            trigger = true;
        }

        //初始化状态机参数
        public void FSMPar()
        {
            fsmBase.InitComponent();
            fsmBase.InitDefaultState();
            currentCharacter.GetComponent<CharacterStatus>().T_AnimaEnd_Attack01 = true;
            currentCharacter.GetComponent<CharacterMotor>().SpeedUPRate = 1;
        }
        //初始化判断参数
        

        public void ChangeCharacterUp()
        {
            if (trigger)
            {
                trigger = false;
                Vector3 LastPostion = currentCharacter.transform.position;
                Quaternion LastRotation = currentCharacter.transform.rotation;

                if (MyCharacters.Count <= 1)
                {
                    Debug.Log("无法替换");
                }
                else
                {
                    currentCharacter.SetActive(false);
                    if (MyCharacters.IndexOf(currentCharacter) < MyCharacters.Count - 1)
                    {
                        currentCharacter = MyCharacters[MyCharacters.IndexOf(currentCharacter) + 1];
                    }
                    else
                    {
                        currentCharacter = MyCharacters[0];
                    }
                    currentCharacter.transform.position = LastPostion + new Vector3(0, 0, 0);
                    currentCharacter.transform.rotation = LastRotation;
                    CamaraConfig.GetComponent<CinemachineVirtualCamera>().m_Follow = currentCharacter.transform;
                    currentCharacter.SetActive(true);
                    currentCharacter.GetComponent<CharacterStatus>().InitConditionPar();
                    trigger = true;
                }
            }
        }
        public void ChangeCharacterDown()
        {
            //currentCharacter.GetComponent<CharacterInputController>().inputActions.Player.ChangeDown.canceled -= currentCharacter.GetComponent<CharacterInputController>().ChangeDownOncanceled;
            if (trigger)
            {
                trigger = false;
                Vector3 LastPostion = currentCharacter.transform.position;
                Quaternion LastRotation = currentCharacter.transform.rotation;
                if (MyCharacters.Count <= 1)
                {
                    Debug.Log("无法替换");
                }
                else
                {
                    currentCharacter.SetActive(false);
                    if (MyCharacters.IndexOf(currentCharacter) > 0)
                    {
                        currentCharacter = MyCharacters[MyCharacters.IndexOf(currentCharacter) - 1];
                    }
                    else
                    {
                        currentCharacter = MyCharacters[MyCharacters.Count - 1];
                    }
                    currentCharacter.transform.position = LastPostion + new Vector3(0, 0, 0);
                    currentCharacter.transform.rotation = LastRotation;
                    CamaraConfig.GetComponent<CinemachineVirtualCamera>().m_Follow = currentCharacter.transform;
                    currentCharacter.SetActive(true);
                    currentCharacter.GetComponent<CharacterStatus>().InitConditionPar();
                    trigger = true;
                }
            }
        }
    }
}
