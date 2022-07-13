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
    /// �����
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
        /// ͨ������� ��������
        /// </summary>
        /// <param name="key">���</param>
        /// <param name="prefab">��Ҫ����ʵ����Ԥ�Ƽ�</param>
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
        //ʹ�ö���
        private static void UseObject(Vector3 pos, Quaternion rotate, GameObject go)
        {
            go.transform.position = pos;
            go.transform.rotation = rotate;
            go.SetActive(true);
            //����ִ��������������Ҫ���õ��߼�
            foreach (var item in go.GetComponents<IResetable>())
            {
                item.onReset();
            }
        }

        //��Ӷ���
        private GameObject AddObjecy(string key, GameObject prefab)
        {
            //��������
            GameObject go = Instantiate(prefab);
            //�������
            //�������û��key����Ӽ�¼
            if (!cache.ContainsKey(key)) cache.Add(key, new List<GameObject>());
            cache[key].Add(go);
            return go;
        }

        //����ָ������п���ʹ�õĶ���
        private GameObject FindUsableObject(string key)
        {
            if (cache.ContainsKey(key))
                return cache[key].Find(g => !g.activeInHierarchy);
            return null;
        }

        /// <summary>
        /// ���ն���
        /// </summary>
        /// <param name="go"></param>
        /// <param name="delay">�ӳ�ʱ��</param>
        public void CollectObject(GameObject go,float delay = 0)
        {
            StartCoroutine(CollectObjectDelay(go, delay));
        }
        private IEnumerator CollectObjectDelay(GameObject go,float delay)
        {
            yield return new WaitForSeconds(delay);
            go.SetActive(false);
        }
        
        //���ĳ�����
        public void Clear(string key)
        {
            //��Ϸ����
            for (int i = cache[key].Count-1; i >= 0; i--)
            {
                Destroy(cache[key][i]);
            }
            //�ֵ�������
            cache.Remove(key);
        }

        public void ClearAll()
        {
            //���ֵ������м�����List����
            foreach (var key in new List<string>(cache.Keys))
            {
                Clear(key);
            }
        }
    }
}
