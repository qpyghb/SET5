using ETModel;
using UnityEngine;

namespace ETHotfix
{
	[ObjectSystem]
	public class SpriteHoldEntityAwakeSystem : AwakeSystem<SpriteHoldEntity>
	{
		public override void Awake(SpriteHoldEntity self)
		{
			self.Awake();
		}
	}

	[ObjectSystem]
	public class SpriteHoldEntityStartSystem : StartSystem<SpriteHoldEntity>
	{
		public override void Start(SpriteHoldEntity self)
		{
			self.Start();
		}
	}

	[ObjectSystem]
	public class SpriteHoldEntityUpdateSystem : UpdateSystem<SpriteHoldEntity>
	{
		public override void Update(SpriteHoldEntity self)
		{
			self.Update();
		}
	}

	[ObjectSystem]
	public class SpriteHoldEntityDestroySystem : DestroySystem<SpriteHoldEntity>
	{
		public override void Destroy(SpriteHoldEntity self)
		{
			self.OnDestroy();
		}
	}

	public class SpriteHoldEntity : Entity
	{
		public ReferenceCollector Collector { get; set; }

		public void Awake()
		{
			GameObject = ResourceUtil.Load<GameObject>("SpriteHold").Instantiate();
			GameObject.AddComponent<ComponentView>().Component = this;
			Collector = GameObject.GetComponent<ReferenceCollector>();
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
	}
}
