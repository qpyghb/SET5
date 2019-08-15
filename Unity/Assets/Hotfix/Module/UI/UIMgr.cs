using ETModel;

namespace ETHotfix
{
	public static class UIMgr
	{
		public static void OpenPanel<T>(string uiName) where T : Component, new()
		{
			UI ui = UIFactory.Create<T>(uiName);
			Game.Scene.GetComponent<UIComponent>().Add(ui);
		}

		public static T GetPanel<T>(string uiName) where T : Component, new()
		{
			return Game.Scene.GetComponent<UIComponent>().Get(uiName).GetComponent<T>();
		}

		public static void ClosePanel(string uiName)
		{
			Game.Scene.GetComponent<UIComponent>().Remove(uiName);
			ETModel.Game.Scene.GetComponent<ResourcesComponent>().UnloadBundle(uiName.StringToAB());
		}
	}
}
