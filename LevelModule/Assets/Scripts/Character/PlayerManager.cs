using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDemo.Character
{
    /// <summary>
    /// 
    /// </summary>
    public class PlayerManager : MonoBehaviour
    {
        public GameObject[] MyCharacters;
        public GameObject currentCharacter;
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
            currentCharacter.SetActive(true);
        }

        
        public void ChangeCharacterUp()
        {
            currentCharacter.SetActive(false);
            if (index==MyCharacters.Length-1)
            {
                currentCharacter = MyCharacters[0];
                index = 0;
                for (int i = 0; i < MyCharacters.Length; i++)
                {
                    if (MyCharacters[i] != currentCharacter)
                    {
                        MyCharacters[i].transform.position = currentCharacter.transform.position;
                    }
                }
            }
            else
            {
                currentCharacter = MyCharacters[index + 1];
                index += 1;
                for (int i = 0; i < MyCharacters.Length; i++)
                {
                    if (MyCharacters[i] != currentCharacter)
                    {
                        MyCharacters[i].transform.position = currentCharacter.transform.position;
                    }
                }
            }
            currentCharacter.SetActive(true);

        }
        public void ChangeCharacterDown()
        {
            currentCharacter.SetActive(false);
            if (index==0)
            {
                currentCharacter = MyCharacters[MyCharacters.Length - 1];
                index = MyCharacters.Length - 1;
            }
            else
            {
                currentCharacter = MyCharacters[index - 1];
                index -= 1;
            }
            currentCharacter.SetActive(true);
        }
    }
}
