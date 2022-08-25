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
        public CharacterInputController inputController;
        public void Awake()
        {
            inputController = GetComponent<CharacterInputController>();
            MyCharacters.AddRange(GameObject.FindGameObjectsWithTag("Player"));
            currentCharacter = MyCharacters[0];
            fsmBase = GetComponent<FSMBase>();
            index = 0;
            for (int i = 1; i < MyCharacters.Count; i++)
            {
                MyCharacters[i].SetActive(false);
            }
            CamaraConfig.GetComponent<CinemachineVirtualCamera>().m_Follow = currentCharacter.transform;
            currentCharacter.SetActive(true);
            inputController.currentPlayer = currentCharacter;
        }

        //初始化状态机参数
        public void FSMPar()
        {
            fsmBase.InitComponent();
            fsmBase.InitDefaultState();
            currentCharacter.GetComponent<CharacterStatus>().T_AnimaEnd_Attack01 = true;
        }
        //初始化判断参数
        

        public void ChangeCharacterUp()
        {
            Vector3 LastPostion = transform.position;
            Quaternion LastRotation = transform.rotation;
            
            
            
            currentCharacter.SetActive(false);
            if (index==MyCharacters.Count-1)
            {
                currentCharacter = MyCharacters[0];
                index = 0;
                for (int i = 0; i < MyCharacters.Count; i++)
                {
                    transform.position = LastPostion+new Vector3(0,0,0);
                    transform.rotation = LastRotation;
                }
            }
            else
            {
                currentCharacter = MyCharacters[index + 1];
                index += 1;
                for (int i = 0; i < MyCharacters.Count; i++)
                {
                    transform.position = LastPostion+new Vector3(0,0,0);
                    transform.rotation = LastRotation;
                }
            }
            inputController.currentPlayer = currentCharacter;
            CamaraConfig.GetComponent<CinemachineVirtualCamera>().m_Follow = currentCharacter.transform;
            currentCharacter.SetActive(true);
            FSMPar();
            currentCharacter.GetComponent<CharacterStatus>().InitConditionPar();
        }
        public void ChangeCharacterDown()
        {
            Vector3 LastPostion = transform.position;
            Quaternion LastRotation = transform.rotation;
            currentCharacter.SetActive(false);
            if (index==0)
            {
                currentCharacter = MyCharacters[MyCharacters.Count - 1];
                index = MyCharacters.Count - 1;
                for (int i = 0; i < MyCharacters.Count; i++)
                {
                    transform.position = LastPostion+new Vector3(0,0,0);
                    transform.rotation = LastRotation;
                }
            }
            else
            {
                currentCharacter = MyCharacters[index - 1];
                index -= 1;
                for (int i = 0; i < MyCharacters.Count; i++)
                {
                    transform.position = LastPostion+new Vector3(0,0,0);
                    transform.rotation = LastRotation;
                }
            }
            inputController.currentPlayer = currentCharacter;
            CamaraConfig.GetComponent<CinemachineVirtualCamera>().m_Follow = currentCharacter.transform;
            currentCharacter.SetActive(true);
            FSMPar();
            currentCharacter.GetComponent<CharacterStatus>().InitConditionPar();
        }
    }
}
