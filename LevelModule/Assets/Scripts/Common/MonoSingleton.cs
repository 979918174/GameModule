using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Common
{
   public class MonoSingleton<T> : MonoBehaviour where T: MonoSingleton<T>
    {
        //T 表示子类类型，约束为这类或者子类
        //public static T Instance { get; private set; }
        private static T instance;

        public static T Instance 
        {
            get 
            {
                //按需加载
                if (instance == null) 
                {
                    //在场景中根据类型查找引用
                    instance = FindObjectOfType<T>();
                    if (instance == null)
                    {
                        //创建脚本对象（立即执行awake）
                        instance = new GameObject("Singleton of " + typeof(T)).AddComponent<T>();
                    }
                    else
                    {
                        instance.Init();
                    }
                } 
                return instance;
            }
        }

        public void Awake()
        {
            if (instance == null)
            {
                instance = this as T;
                Init();
            }
        }

        //子类做初始化
        public virtual void Init() 
        { 
        
        }
    }
}
