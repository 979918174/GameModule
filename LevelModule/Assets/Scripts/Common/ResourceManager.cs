using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            string fileContent = GetConfigFile();
            //解析文件（string ----> Dictionary<string,stirng>）
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
