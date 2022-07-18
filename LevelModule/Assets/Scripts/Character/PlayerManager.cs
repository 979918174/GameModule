using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace GameDemo.Character
{
    /// <summary>
    /// 
    /// </summary>
    public class PlayerManager : MonoBehaviour
    {
        public GameObject[] MyCharacters;
        public GameObject currentCharacter;
        public GameObject CamaraConfig;
        public int index;
        public void Awake()
        {
            MyCharacters = GameObject.FindGameObjectsWithTag("Player");
            currentCharacter = MyCharacters[0];
            index = 0;
            for (int i = 1; i < MyCharacters.Length; i++)
            {
                MyCharacters[i].SetActive(false);
            }
            CamaraConfig.GetComponent<CinemachineVirtualCamera>().m_Follow = currentCharacter.transform;
            currentCharacter.SetActive(true);
        }

        
        public void ChangeCharacterUp()
        {
            Vector3 LastPostion = currentCharacter.transform.position;
            Quaternion LastRotation = currentCharacter.transform.rotation;
            currentCharacter.SetActive(false);
            

            if (index==MyCharacters.Length-1)
            {
                currentCharacter = MyCharacters[0];
                index = 0;
                for (int i = 0; i < MyCharacters.Length; i++)
                {
                    MyCharacters[i].transform.position = LastPostion;
                    MyCharacters[i].transform.rotation = LastRotation;
                }
            }
            else
            {
                currentCharacter = MyCharacters[index + 1];
                index += 1;
                for (int i = 0; i < MyCharacters.Length; i++)
                {
                    MyCharacters[i].transform.position = LastPostion;
                    MyCharacters[i].transform.rotation = LastRotation;
                }
            }
            CamaraConfig.GetComponent<CinemachineVirtualCamera>().m_Follow = currentCharacter.transform;
            currentCharacter.SetActive(true);

        }
        public void ChangeCharacterDown()
        {
            Vector3 LastPostion = currentCharacter.transform.position;
            Quaternion LastRotation = currentCharacter.transform.rotation;
            currentCharacter.SetActive(false);
            if (index==0)
            {
                currentCharacter = MyCharacters[MyCharacters.Length - 1];
                index = MyCharacters.Length - 1;
                for (int i = 0; i < MyCharacters.Length; i++)
                {
                    MyCharacters[i].transform.position = LastPostion;
                    MyCharacters[i].transform.rotation = LastRotation;
                }
            }
            else
            {
                currentCharacter = MyCharacters[index - 1];
                index -= 1;
                for (int i = 0; i < MyCharacters.Length; i++)
                {
                    MyCharacters[i].transform.position = LastPostion;
                    MyCharacters[i].transform.rotation = LastRotation;
                }
            }
            CamaraConfig.GetComponent<CinemachineVirtualCamera>().m_Follow = currentCharacter.transform;
            currentCharacter.SetActive(true);
        }
    }
}
