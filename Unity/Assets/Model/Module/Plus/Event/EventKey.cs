using UnityEngine;

namespace ETModel
{
	public enum EventKey
	{
		#region Collider2dObserver

		/// <summary>
		/// GameObject, Collision2D
		/// </summary>
		OnCollisionEnter2D,

		/// <summary>
		/// GameObject, Collision2D
		/// </summary>
		OnCollisionStay2D,

		/// <summary>
		/// GameObject, Collision2D
		/// </summary>
		OnCollisionExit2D,

		/// <summary>
		/// GameObject, Collider2D
		/// </summary>
		OnTriggerEnter2D,

		/// <summary>
		/// GameObject, Collider2D
		/// </summary>
		OnTriggerStay2D,

		/// <summary>
		/// GameObject, Collider2D
		/// </summary>
	    OnTriggerExit2D,

		#endregion

		#region ColliderOberserver

		/// <summary>
		/// GameObject, Collision
		/// </summary>
		OnCollisionEnter,

		/// <summary>
		/// GameObject, Collision
		/// </summary>
		OnCollisionStay,

		/// <summary>
		/// GameObject, Collision
		/// </summary>
		OnCollisionExit,

		/// <summary>
		/// GameObject, Collider
		/// </summary>
		OnTriggerEnter,

		/// <summary>
		/// GameObject, Collider
		/// </summary>
		OnTriggerStay,

		/// <summary>
		/// GameObject, Collider
		/// </summary>
		OnTriggerExit,

		#endregion
	}
}
