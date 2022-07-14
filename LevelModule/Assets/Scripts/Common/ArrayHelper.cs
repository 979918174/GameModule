using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    /// <summary>
    /// 数组助手类：对数组的改造和操作
    /// </summary>
    public static class ArrayHelper
    {
    //7个方法
    //查找，查找所有满足条件的所有对象
    //排序【升序，降序】最大值，最小值，筛选
        /// <summary>
        /// 查找满足条件的单个元素
        /// </summary>
        /// <param name="array">数组</param>
        /// <param name="condition">查找条件</param>
        /// <typeparam name="T">数组类型</typeparam>
        /// <returns></returns>
        public static T Find<T>(T[] array,Func<T,bool> condition)
        {
            for (int i = 0; i < array.Length; i++)
            {
                //满足条件，调用者指定相应的条件
                if (condition(array[i]))
                {
                    return array[i];
                }
            }
            return default(T);
        }
        
        public static T[] FindAll<T>(T[] array,Func<T,bool> condition) {
            List<T> list = new List<T>();
            for (int i = 0; i < array.Length; i++)
            {
                if (condition(array[i]))
                {
                    list.Add(array[i]); 
                }
            }
                return list.ToArray();
        }

        public static List<T> FindAll_L<T>(List<T> list, Func<T, bool> condition)
        {

            List<T> listTemp = new List<T>();
            for (int i = 0; i < list.Count; i++)
            {
                if (condition(list[i]))
                {
                    listTemp.Add(list[i]);
                }
            }
            return listTemp;
        }

        /// <summary>
        /// 最大值
        /// </summary>
        /// <param name="array">比较的数组</param>
        /// <param name="condition">比较的方法</param>
        /// <typeparam name="T">数组类型</typeparam>
        /// <typeparam name="Q">比较条件的返回值类型</typeparam>
        /// <returns></returns>
        public static T GetMax<T,Q>(T[] array, Func<T,Q> condition) where Q:IComparable
        {
            T max = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                //比较的条件
                if (condition(max).CompareTo(condition(array[i]))<0)
                {
                    max = array[i];
                }
            }
            return max;
        }
        
        public static T GetMin<T,Q>(T[] array, Func<T,Q> condition) where Q:IComparable
        {
            T min = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                //比较的条件
                if (condition(min).CompareTo(condition(array[i]))>0)
                {
                    min = array[i];
                }
            }
            return min;
        }
        /// <summary>
        /// 升序方法
        /// </summary>
        /// <param name="array"></param>
        /// <param name="condition"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="Q"></typeparam>
        public static T[] OrderDescending<T,Q>(T[] array,Func<T,Q> condition) where Q:IComparable
        {
            for (int i = 0; i < array.Length-1; i++)
            {
                for (int j = 0; j < array.Length-1-i; j++)
                {
                    if (condition(array[j]).CompareTo(condition(array[j+1]))>0)
                    {
                        T temp = array[j];
                        array[j] = array[j+1];
                        array[j+1] = temp;
                    }
                }
            }

            return array;
        }
        
        public static T[] OrderAscending<T,Q>(T[] array,Func<T,Q> condition) where Q:IComparable
        {
            for (int i = 0; i < array.Length-1; i++)
            {
                for (int j = 0; j < array.Length-1-i; j++)
                {
                    if (condition(array[j]).CompareTo(condition(array[j+1]))<0)
                    {
                        T temp = array[j];
                        array[j] = array[j+1];
                        array[j+1] = temp;
                    }
                }
            }

            return array;
        }

        public static Q[] Select<T,Q>(T[] array,Func<T,Q> condition)
        {
            //存储筛选出来满足条件的元素
            Q[] result = new Q[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                result[i] = condition(array[i]);
            }
            return result;
        }
    }
}
