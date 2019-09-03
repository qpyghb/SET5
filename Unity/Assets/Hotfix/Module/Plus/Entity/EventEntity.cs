using ETModel;
using UnityEngine;

namespace ETHotfix
{
	[ObjectSystem]
	public class EventEntityAwakeSystem : AwakeSystem<EventEntity>
	{
		public override void Awake(EventEntity self)
		{
			self.Awake();
		}
	}

	[ObjectSystem]
	public class EventEntityStartSystem : StartSystem<EventEntity>
	{
		public override void Start(EventEntity self)
		{
			self.Start();
		}
	}

	[ObjectSystem]
	public class EventEntityUpdateSystem : UpdateSystem<EventEntity>
	{
		public override void Update(EventEntity self)
		{
			self.Update();
		}
	}

	[ObjectSystem]
	public class EventEntityDestroySystem : DestroySystem<EventEntity>
	{
		public override void Destroy(EventEntity self)
		{
			self.OnDestroy();
		}
	}

	public class EventEntity : Entity
	{
		public void Awake()
		{

		}

		public void Start()
		{

		}

		public void Update()
		{
			ETModel.EventEntity modelEventEntity = ETModel.Game.Scene.GetComponent<ETModel.EventEntity>();
			if (modelEventEntity == null) return;

			for (int i = 0; i < modelEventEntity.eventInfoList.Count; i++)
			{
				EventInfo info = modelEventEntity.eventInfoList[i];
				EventMgr.Send(info.name, info.args);
			}

			modelEventEntity.eventInfoList.Clear();
		}

		public void OnDestroy()
		{

		}

		public override void Dispose()
		{
			if (IsDisposed) return;
			base.Dispose();
		}
	}
}
