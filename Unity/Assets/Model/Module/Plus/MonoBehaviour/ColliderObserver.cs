using UnityEngine;

namespace ETModel
{
	public class ColliderObserver : MonoBehaviour
	{
		private void OnCollisionEnter(Collision collision)
		{
			Game.Scene.GetComponent<EventEntity>().eventInfoList.Add(new EventInfo(EventType.OnCollisionEnter, gameObject, collision));
		}

		private void OnCollisionStay(Collision collision)
		{
			Game.Scene.GetComponent<EventEntity>().eventInfoList.Add(new EventInfo(EventType.OnCollisionStay, gameObject, collision));
		}

		private void OnCollisionExit(Collision collision)
		{
			Game.Scene.GetComponent<EventEntity>().eventInfoList.Add(new EventInfo(EventType.OnCollisionExit, gameObject, collision));
		}

		private void OnTriggerEnter(Collider other)
		{
			Game.Scene.GetComponent<EventEntity>().eventInfoList.Add(new EventInfo(EventType.OnTriggerEnter, gameObject, other));
		}

		private void OnTriggerStay(Collider other)
		{
			Game.Scene.GetComponent<EventEntity>().eventInfoList.Add(new EventInfo(EventType.OnTriggerStay, gameObject, other));
		}

		private void OnTriggerExit(Collider other)
		{
			Game.Scene.GetComponent<EventEntity>().eventInfoList.Add(new EventInfo(EventType.OnTriggerExit, gameObject, other));
		}
	}
}
