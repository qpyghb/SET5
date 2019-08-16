using ETModel;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace ETHotfix
{
	[ObjectSystem]
	public class TipPanelComponentAwakeSystem : AwakeSystem<TipPanelComponent>
	{
		public override void Awake(TipPanelComponent self)
		{
			self.Awake();
		}
	}

	[ObjectSystem]
	public class TipPanelComponentStartSystem : StartSystem<TipPanelComponent>
	{
		public override void Start(TipPanelComponent self)
		{
			self.Start();
		}
	}

	[ObjectSystem]
	public class TipPanelComponentUpdateSystem : UpdateSystem<TipPanelComponent>
	{
		public override void Update(TipPanelComponent self)
		{
			self.Update();
		}
	}

	[ObjectSystem]
	public class TipPanelComponentDestroySystem : DestroySystem<TipPanelComponent>
	{
		public override void Destroy(TipPanelComponent self)
		{
			self.OnDestroy();
		}
	}

	public class TipPanelComponent: Component
	{
		private ReferenceCollector mCollector;
		private Text tipText;

		public void Awake()
		{
			mCollector = GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
			tipText = mCollector.Get<GameObject>("TipText").GetComponent<Text>();
		}

		public void Start()
		{
			tipText.transform.DOLocalMoveY(300f, 0.6f).From(200f);
			DoFade().Coroutine();
			AutoClose().Coroutine();
		}

		public void Update()
		{

		}

		public void OnDestroy()
		{

		}

		public void SetTip(string tip)
		{
			tipText.text = tip;
		}

		private async ETVoid DoFade()
		{
			Color targetColor = new Color(1f, 1f, 1f, 1f);
			Color fromColor = new Color(1f, 1f, 1f, 0.3f);
			tipText.color = fromColor;
			for (int i = 0; i < 60; i++)
			{
				if (tipText == null) return;

				tipText.color = (fromColor + targetColor) * i / 60;
				await ETModel.Game.Scene.GetComponent<TimerComponent>().WaitAsync(600 / 60);
			}
		}

		private async ETVoid AutoClose()
		{
			await ETModel.Game.Scene.GetComponent<TimerComponent>().WaitAsync(1000);
			UIMgr.ClosePanel("TipPanel");
		}
	}
}
