using ETModel;
using System;

namespace ETHotfix
{
	public static class SceneUtil
	{
		public static async ETVoid LoadScene(string sceneName, Action onLoaded = null)
		{
			// 加载场景资源
			await ETModel.Game.Scene.GetComponent<ResourcesComponent>().LoadBundleAsync(sceneName.StringToAB());
			// 切换到map场景
			using (SceneChangeComponent sceneChangeComponent = ETModel.Game.Scene.AddComponent<SceneChangeComponent>())
			{
				await sceneChangeComponent.ChangeSceneAsync(sceneName);
			}

			onLoaded?.Invoke();
		}
	}
}
