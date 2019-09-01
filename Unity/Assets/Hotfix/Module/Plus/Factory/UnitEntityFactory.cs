using ETModel;
using UnityEngine;

namespace ETHotfix
{
	public static class UnitEntityFactory
	{
		public static T Create<T>(string prefabName, Vector3 generatePos) where T : Entity
		{
			GameObject go = ResourceUtil.Load<GameObject>(prefabName).Instantiate().Position(generatePos);
			T entity = ComponentFactory.Create<T, GameObject>(go);
			Game.Scene.GetComponent<UnitEntity>().Add(entity);
			return entity;
		}
	}
}
