using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

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
            string fileContent = GetTextFromStreamingAssets("ConfigMap.txt");
            //�����ļ���string ----> Dictionary<string,stirng>��
            BuildMap(fileContent);
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
        
        /// <summary>
        ///��ȡStreamingAssets�е��ļ�
        /// </summary>
        /// <param name="path">StreamingAssets�µ��ļ�·��</param>
        /// <returns>��ȡ�����ַ���</returns>
        public static string GetTextFromStreamingAssets(string path)
        {
            string localPath = "";
            if (Application.platform == RuntimePlatform.Android)
            {
                localPath = Application.streamingAssetsPath + "/" + path;
            }
            else
            {
                localPath = "file:///" + Application.streamingAssetsPath + "/" + path;
            }
            UnityWebRequest requrest = UnityWebRequest.Get(localPath);
            var operation = requrest.SendWebRequest();
            while (!operation.isDone)
            { }
            if (requrest.isNetworkError || requrest.isHttpError)
            {
                return "";
            }
            else
            {
                return requrest.downloadHandler.text;
            }

        }
    }
}
