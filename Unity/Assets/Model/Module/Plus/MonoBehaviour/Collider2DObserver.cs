using ETHotfix;
using UnityEngine;

namespace ETModel
{
	public class Collider2DObserver : MonoBehaviour
	{
		private void OnCollisionEnter2D(Collision2D collision)
		{
			Game.Scene.GetComponent<EventEntity>().eventInfoList.Add(new EventInfo(EventType.OnCollisionEnter2D, gameObject, collision));
		}

		private void OnCollisionStay2D(Collision2D collision)
		{
			Game.Scene.GetComponent<EventEntity>().eventInfoList.Add(new EventInfo(EventType.OnCollisionStay2D, gameObject, collision));
		}

		private void OnCollisionExit2D(Collision2D collision)
		{
			Game.Scene.GetComponent<EventEntity>().eventInfoList.Add(new EventInfo(EventType.OnCollisionExit2D, gameObject, collision));
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			Game.Scene.GetComponent<EventEntity>().eventInfoList.Add(new EventInfo(EventType.OnTriggerEnter2D, gameObject, collision));
		}

		private void OnTriggerStay2D(Collider2D collision)
		{
			Game.Scene.GetComponent<EventEntity>().eventInfoList.Add(new EventInfo(EventType.OnTriggerStay2D, gameObject, collision));
		}

		private void OnTriggerExit2D(Collider2D collision)
		{
			Game.Scene.GetComponent<EventEntity>().eventInfoList.Add(new EventInfo(EventType.OnTriggerExit2D, gameObject, collision));
		}
	}
}
