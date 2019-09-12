using ETHotfix;
using UnityEngine;

namespace ETModel
{
	public class Collider2DObserver : MonoBehaviour
	{
		private void OnCollisionEnter2D(Collision2D collision)
		{
			Game.Scene.GetComponent<EventEntity>().Add(EventType.OnCollisionEnter2D, gameObject, collision);
		}

		private void OnCollisionStay2D(Collision2D collision)
		{
			Game.Scene.GetComponent<EventEntity>().Add(EventType.OnCollisionStay2D, gameObject, collision);
		}

		private void OnCollisionExit2D(Collision2D collision)
		{
			Game.Scene.GetComponent<EventEntity>().Add(EventType.OnCollisionExit2D, gameObject, collision);
		}

		private void OnTriggerEnter2D(Collider2D collider)
		{
			Game.Scene.GetComponent<EventEntity>().Add(EventType.OnTriggerEnter2D, gameObject, collider);
		}

		private void OnTriggerStay2D(Collider2D collider)
		{
			Game.Scene.GetComponent<EventEntity>().Add(EventType.OnTriggerStay2D, gameObject, collider);
		}

		private void OnTriggerExit2D(Collider2D collider)
		{
			Game.Scene.GetComponent<EventEntity>().Add(EventType.OnTriggerExit2D, gameObject, collider);
		}
	}
}
