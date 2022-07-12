using System.Collections;
using System.Collections.Generic;
using System.IO;
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
            string fileContent = GetConfigFile("ConfigMap");
            //�����ļ���string ----> Dictionary<string,stirng>��
            BuildMap(fileContent);
        }
        public static string GetConfigFile(string fileName)
        {
            string url = "file://" + Application.dataPath + "/StreamingAssets/" + fileName;
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
            //�ַ�����ȡ�������ж�ȡ�ַ�������
            using (StringReader reader = new StringReader(fileContent)) 
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    //����
                    string[] keyValue = line.Split('=');
                    configMap.Add(keyValue[0], keyValue[1]);
                }            
            }//�������˳�using����飬���Զ�����reader.Dispose()����
        }

        public static T Load<T>(string prefabName) where T : Object
        {
            string prefabPath = configMap[prefabName];
            return Resources.Load<T>(prefabPath);
        }
    }
}
