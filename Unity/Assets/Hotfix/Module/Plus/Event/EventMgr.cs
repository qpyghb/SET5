using ETModel;
using UnityEngine;
using System;
using System.Reflection;
using System.Collections.Generic;


namespace ETHotfix
{
	public class EventMgr
	{
		private struct MethodData
		{
			public object obj;
			public MethodInfo method;
		}

		// 事件字典
		private static Dictionary<string, List<MethodData>> eventDic = new Dictionary<string, List<MethodData>>();

		/// <summary>
		/// 注册
		/// </summary>
		/// <param name="obj">注册的对象</param>
		/// <param name="eventName">事件名</param>
		public static void Register(object obj, string eventName)
		{
			// 先注销此对象的此事件，防止重复注册
			Deregister(obj, eventName);

			// 新建 Pair(对象，方法)
			MethodData methodData = new MethodData();
			methodData.obj = obj;
			methodData.method = obj.GetType().GetMethod(eventName);

			// 判断此对象是否存在此方法
			if (methodData.method == null)
			{
				Debug.LogError($"注册事件出错: 对象({obj}) 并没有对应的方法({eventName})");
			}

			// 尝试从方法组获取此方法, 或创建一个
			List<MethodData> methodDataList = null;
			if (!eventDic.TryGetValue(eventName, out methodDataList))
			{
				methodDataList = new List<MethodData>();
				methodDataList.Add(methodData);
				eventDic.Add(eventName, methodDataList);
			}
			// 注册过了，直接添加进去
			else
			{
				methodDataList.Add(methodData);
			}
		}

		/// <summary>
		/// 注销指定对象的所有方法
		/// </summary>
		/// <param name="obj">对象</param>
		public static void Deregister(object obj)
		{
			// 是否Enumerator进行迭代
			var iter = eventDic.GetEnumerator();
			while (iter.MoveNext())
			{
				List<MethodData> methodDataList = iter.Current.Value;
				for (int i = 0; i < methodDataList.Count; i++)
				{
					if (obj == methodDataList[i].obj)
					{
						methodDataList.RemoveAt(i);
					}
				}
			}
		}

		/// <summary>
		/// 发送事件
		/// </summary>
		/// <param name="eventName">事件名</param>
		/// <param name="args">参数</param>
		public static void Send(string eventName, params object[] args)
		{
			Invoke(eventName, false, args);
		}

		/// <summary>
		/// 有返回值调用
		/// </summary>
		/// <param name="eventName">事件名</param>
		/// <param name="args">参数</param>
		/// <returns>事件返回值列表</returns>
		public static List<object> Call(string eventName, params object[] args)
		{
			return Invoke(eventName, true, args);
		}

		// 返回的数据
		private static List<object> returnObjects = new List<object>();

		/// <summary>
		/// 调用事件
		/// </summary>
		/// <param name="eventName">方法名</param>
		/// <param name="needReturn"></param>
		/// <param name="args"></param>
		/// <returns></returns>
		private static List<object> Invoke(string eventName, bool needReturn, params object[] args)
		{
			// 清空返回值
			returnObjects.Clear();

			// 从事件组获取 pair 列表
			List<MethodData> methodDataList = null;
			if (!eventDic.TryGetValue(eventName, out methodDataList))
			{
				return returnObjects;
			}

			// 调用所有方法
			for (int i = 0; i < methodDataList.Count; i++)
			{
				MethodData methodData = methodDataList[i];

				try
				{
					if (needReturn)
					{
						returnObjects.Add(methodData.method.Invoke(methodData.obj, args));
					}
					else
					{
						methodData.method.Invoke(methodData.obj, args);
					}
				}
				catch (Exception e)
				{
					Debug.LogError($"此方法({methodData.method.DeclaringType.FullName})，出错信息: {e.ToString()}");
				}
			}
			return returnObjects;
		}

		/// <summary>
		/// 注销指定对象的指定事件
		/// </summary>
		/// <param name="obj">对象</param>
		/// <param name="eventName">注销的方法名</param>
		private static void Deregister(object obj, string eventName)
		{
			// 获取方法数据列表
			List<MethodData> methodDataList = null;
			if (!eventDic.TryGetValue(eventName, out methodDataList))
			{
				return;
			}

			// 便利
			for (int i = 0; i < methodDataList.Count; i++)
			{
				if (obj == methodDataList[i].obj)
				{
					methodDataList.RemoveAt(i);
					return;
				}
			}
		}
	}
}
