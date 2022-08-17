using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public interface IResetable 
    {
        void onReset();
    }
    /// <summary>
    /// 对象池
    /// </summary>
    public class GameObjectPool : MonoSingleton<GameObjectPool>
    {
        private Dictionary<string, List<GameObject>> cache;

        public override void Init()
        {
            base.Init();
            cache = new Dictionary<string, List<GameObject>>();
        }
        /// <summary>
        /// 通过对象池 创建对象
        /// </summary>
        /// <param name="key">类别</param>
        /// <param name="prefab">需要创建实例的预制件</param>
        /// <param name="pos"></param>
        /// <param name="rotate"></param>
        /// <returns></returns>
        public GameObject CreateObject(string key, GameObject prefab, Vector3 pos, Quaternion rotate)
        {
            GameObject go = FindUsableObject(key);
            if (go == null)
            {
                go = AddObjecy(key, prefab);
            }
                UseObject(pos, rotate, go);
                return go;
            
        }
        //使用对象
        private static void UseObject(Vector3 pos, Quaternion rotate, GameObject go)
        {
            go.transform.position = pos;
            go.transform.rotation = rotate;
            go.SetActive(true);
            //遍历执行物体中所有需要重置的逻辑
            foreach (var item in go.GetComponents<IResetable>())
            {
                item.onReset();
            }
        }

        //添加对象
        private GameObject AddObjecy(string key, GameObject prefab)
        {
            //创建对象
            GameObject go = Instantiate(prefab);
            //加入池中
            //如果池中没有key，添加记录
            if (!cache.ContainsKey(key)) cache.Add(key, new List<GameObject>());
            cache[key].Add(go);
            return go;
        }

        //查找指定类别中可以使用的对象
        private GameObject FindUsableObject(string key)
        {
            if (cache.ContainsKey(key))
                return cache[key].Find(g => !g.activeInHierarchy);
            return null;
        }

        /// <summary>
        /// 回收对象
        /// </summary>
        /// <param name="go"></param>
        /// <param name="delay">延迟时间</param>
        public void CollectObject(GameObject go,float delay = 0)
        {
            StartCoroutine(CollectObjectDelay(go, delay));
        }
        private IEnumerator CollectObjectDelay(GameObject go,float delay)
        {
            yield return new WaitForSeconds(delay);
            go.SetActive(false);
        }
        
        //清空某个类别
        public void Clear(string key)
        {
            //游戏对象
            for (int i = cache[key].Count-1; i >= 0; i--)
            {
                Destroy(cache[key][i]);
            }
            //字典里的类别
            cache.Remove(key);
        }

        public void ClearAll()
        {
            //将字典中所有键存入List集合
            foreach (var key in new List<string>(cache.Keys))
            {
                Clear(key);
            }
        }
    }
}
