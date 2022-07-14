using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace Common
{
    /// <summary>
    /// 资源管理器
    /// </summary>
    public class ResourceManager
    {
        private static Dictionary<string, string> configMap;
        //作用：初始化类的静态数据成员
        //时机：类被加载时执行一次
        static ResourceManager()
        {
            //加载文件
            string fileContent = GetTextFromStreamingAssets("ConfigMap.txt");
            //解析文件（string ----> Dictionary<string,stirng>）
            BuildMap(fileContent);
        }

        public static void BuildMap(string fileContent)
        {
            configMap = new Dictionary<string, string>();
            //字符串读取器，逐行读取字符串功能
            using (StringReader reader = new StringReader(fileContent)) 
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    //解析
                    string[] keyValue = line.Split('=');
                    configMap.Add(keyValue[0], keyValue[1]);
                }            
            }//当程序退出using代码块，将自动调用reader.Dispose()方法
        }

        public static T Load<T>(string prefabName) where T : Object
        {
            string prefabPath = configMap[prefabName];
            return Resources.Load<T>(prefabPath);
        }
        
        /// <summary>
        ///读取StreamingAssets中的文件
        /// </summary>
        /// <param name="path">StreamingAssets下的文件路径</param>
        /// <returns>读取到的字符串</returns>
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
