using ETHotfix;
using UnityEngine;

namespace ETModel
{
	public class FXRecycle : MonoBehaviour
	{
		public string poolName;
		public ParticleSystem particle;

		private void Update()
		{
			if (particle.IsAlive() == false)
			{
				GameObjectPool.Recycle(poolName, gameObject);
			}
		}
	}
}
