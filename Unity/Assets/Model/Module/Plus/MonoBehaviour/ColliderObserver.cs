using ETHotfix;
using UnityEngine;

namespace ETModel
{
	public class ColliderObserver : MonoBehaviour
	{
		private void OnCollisionEnter(Collision collision)
		{
			Game.Scene.GetComponent<EventEntity>().Add(EventType.OnCollisionEnter, gameObject, collision);
		}

		private void OnCollisionStay(Collision collision)
		{
			Game.Scene.GetComponent<EventEntity>().Add(EventType.OnCollisionStay, gameObject, collision);
		}

		private void OnCollisionExit(Collision collision)
		{
			Game.Scene.GetComponent<EventEntity>().Add(EventType.OnCollisionExit, gameObject, collision);
		}

		private void OnTriggerEnter(Collider collider)
		{
			Game.Scene.GetComponent<EventEntity>().Add(EventType.OnTriggerEnter, gameObject, collider);
		}

		private void OnTriggerStay(Collider collider)
		{
			Game.Scene.GetComponent<EventEntity>().Add(EventType.OnTriggerStay, gameObject, collider);
		}

		private void OnTriggerExit(Collider collider)
		{
			Game.Scene.GetComponent<EventEntity>().Add(EventType.OnTriggerExit, gameObject, collider);
		}
	}
}
