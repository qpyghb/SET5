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

		#region Texture2D

		public static Sprite ToSprite(this Texture2D self)
		{
			Sprite sprite = Sprite.Create(self, new Rect(0f, 0f, self.width, self.height), Vector2.one * 0.5f);
			sprite.name = self.name;
			return sprite;
		}

		#endregion
	}
}
