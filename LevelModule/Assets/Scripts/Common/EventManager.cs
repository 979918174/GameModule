using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace Common
{
    public interface IEventInfo { }

    public class EventInfo<T> : IEventInfo 
    {
        public UnityAction<T> action;

    }
    public class EventInfo : IEventInfo
    {
        public UnityAction action;

    }
    public class EventManager
    {
        private static EventManager instance;
        public static EventManager Instance 
        {
            get 
            {
                if (instance == null)
                {
                    instance = new EventManager();
                }
                return instance;
            }
        }

        public Dictionary<string, IEventInfo> actionDic = new Dictionary<string, IEventInfo>();

        //添加事件
        public void AddEventListener<T>(string name, UnityAction<T> action) 
        {
            if (actionDic.ContainsKey(name))
            {
                (actionDic[name] as EventInfo<T>).action += action;
            }
            else
            {
                actionDic.Add(name, new EventInfo<T>() { action = action});
            }
        }
        //触发事件
        public void TriggerEventListener<T>(string name,T par)
        {
            if (actionDic.ContainsKey(name))
            {
                (actionDic[name] as EventInfo<T>).action?.Invoke(par);
            }
        }
        //移除事件
        public void RemoveEventListener<T>(string name, UnityAction<T> action)
        {
            if (actionDic.ContainsKey(name))
            {
                (actionDic[name] as EventInfo<T>).action -= action;
            }
        }
        //清空事件
        public void CleanEventListener()
        {
            actionDic.Clear();
        }
    }

}
