using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    /// <summary>
    /// ��Դ������
    /// </summary>
    public class ResourceManager
    {
        private static Dictionary<string, string> configMap;
        //���ã���ʼ����ľ�̬���ݳ�Ա
        //ʱ�����౻����ʱִ��һ��
        static ResourceManager()
        {
            //�����ļ�
            string fileContent = GetConfigFile();
            //�����ļ���string ----> Dictionary<string,stirng>��
            BuildMap(fileContent);
        }
        public static string GetConfigFile()
        {
            string url = "file://" + Application.streamingAssetsPath + "/ConfigMap.txt";
            WWW www = new WWW(url);
            while (true)
            {
                if (www.isDone)
                    return www.text;
            }
        }

        public static void BuildMap(string fileContent)
        {
            configMap = new Dictionary<string, string>();
        
        }

        public static T Load<T>(string prefabName) where T : Object
        {
            string prefabPath = configMap[prefabName];
            return Resources.Load<T>(prefabPath);
        }
    }
}
