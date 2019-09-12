using ETModel;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace ETHotfix
{
	public static class PlusExtension
	{
		#region Component

		public static async ETVoid Delay(this Component self, long delayMs, Action callback)
		{
			await ETModel.Game.Scene.GetComponent<TimerComponent>().WaitAsync(delayMs);
			if (self != null)
			{
				callback.Invoke();
			}
		}

		#endregion

		#region object

		public static void Register(this object self, string eventName)
		{
			EventMgr.Register(self, eventName);
		}

		public static void Deregister(this object self)
		{
			EventMgr.Deregister(self);
		}

		public static void Send(this object self, string eventName, params object[] args)
		{
			EventMgr.Send(eventName, args);
		}

		public static object[] Call(this object self, string eventName, params object[] args)
		{
			return EventMgr.Call(eventName, args);
		}

		#endregion
	}
}
