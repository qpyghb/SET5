using ETHotfix;
using UnityEngine;
using System.Collections.Generic;

namespace ETModel
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

	public struct EventInfo
	{
		public string eventName;
		public object[] args;

		public EventInfo(string eventName, object[] args)
		{
			this.eventName = eventName;
			this.args = args;
		}
	}

	public class EventEntity : Entity
	{
		private List<EventInfo> eventInfoList = new List<EventInfo>();

		public void Awake()
		{

		}

		public void Start()
		{

		}

		public void Update()
		{

		}

		public void OnDestroy()
		{

		}

		public override void Dispose()
		{
			if (IsDisposed) return;
			base.Dispose();
		}

		public void Add(string eventName, params object[] args)
		{
			eventInfoList.Add(new EventInfo(eventName, args));
		}

		public List<EventInfo> GetAll()
		{
			return eventInfoList;
		}

		public void Clear()
		{
			eventInfoList.Clear();
		}
	}
}
