using ETHotfix;
using UnityEngine;

namespace ETModel
{
	public class AnimatorObserver : MonoBehaviour
	{
		public void Send(string msg)
		{
			Game.Scene.GetComponent<EventEntity>().Add(msg);
		}
	}
}
