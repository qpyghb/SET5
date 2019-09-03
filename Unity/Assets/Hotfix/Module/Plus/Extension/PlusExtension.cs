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

		#region Text

		/// <summary>
		/// 颜色渐变
		/// </summary>
		/// <param name="delayMs">延迟的ms</param>
		/// <param name="from">原来的颜色</param>
		/// <param name="target">目标颜色</param>
		public static async ETVoid DoFade(this Text self, long delayMs, Color from, Color target)
		{
			long frameCount = delayMs / 20;
			self.color = from;
			for (long i = 0; i < frameCount; i++)
			{
				if (self == null) return;

				self.color = (from + target) * i / frameCount;
				await ETModel.Game.Scene.GetComponent<TimerComponent>().WaitAsync(20);
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

		#region GameObject

		public static void Destroy(this GameObject self, float delay = 0f)
		{
			GameObject.Destroy(self, delay);
		}

		public static GameObject Instantiate(this GameObject self)
		{
			return GameObject.Instantiate(self);
		}

		public static GameObject Position(this GameObject self, Vector3 pos)
		{
			self.transform.position = pos;
			return self;
		}

		public static GameObject Enable(this GameObject self)
		{
			self.SetActive(true);
			return self;
		}

		public static GameObject Disable(this GameObject self)
		{
			self.SetActive(false);
			return self;
		}

		#endregion

		#region Vector3

		public static Vector2 ToVector2(this Vector3 self)
		{
			return new Vector2(self.x, self.y);
		}

		#endregion
	}
}
