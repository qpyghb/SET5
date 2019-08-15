using ETModel;

namespace ETHotfix
{
	public static class SceneMgr
	{
		public static async void LoadScene(string sceneName)
		{
			// 加载场景资源
			await ETModel.Game.Scene.GetComponent<ResourcesComponent>().LoadBundleAsync(sceneName.StringToAB());
			// 切换到map场景
			using (SceneChangeComponent sceneChangeComponent = ETModel.Game.Scene.AddComponent<SceneChangeComponent>())
			{
				await sceneChangeComponent.ChangeSceneAsync(sceneName);
			}
		}
	}
}
