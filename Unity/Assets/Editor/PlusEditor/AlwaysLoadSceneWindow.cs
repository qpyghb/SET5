using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using ETModel;
using System.IO;

namespace ETPlus
{
	public class AlwaysLoadSceneWindowData
	{
		public string initSceneName = "Init";
	}

	public class AlwaysLoadSceneWindow : EditorWindow
	{
		private const string path = @"./Assets/Res/Config/AlwaysLoadSceneWindowData.txt";
		private AlwaysLoadSceneWindowData data;

		[MenuItem("Tools/Plus/Start Scene #s", priority = 0)]
		private static void ShowWindow()
		{
			AlwaysLoadSceneWindow window = EditorWindow.GetWindow<AlwaysLoadSceneWindow>() as AlwaysLoadSceneWindow;
			window.minSize = new Vector2(300, 50);
			window.Show();
		}

		private void OnEnable()
		{
			this.titleContent = new GUIContent("Start Scene");
			if (File.Exists(path))
			{
				this.data = JsonHelper.FromJson<AlwaysLoadSceneWindowData>(File.ReadAllText(path));
			}
			else
			{
				this.data = new AlwaysLoadSceneWindowData();
			}
		}

		private void OnGUI()
		{
			GUILayout.BeginVertical("box", GUILayout.Width(300));
			{
				GUILayout.BeginHorizontal();
				{
					GUILayout.Label("初始场景:");
					GUILayout.FlexibleSpace();
					string currentName = GUILayout.TextField(data.initSceneName, GUILayout.Width(200));
					if (currentName != data.initSceneName)
					{
						data.initSceneName = currentName;
						File.WriteAllText(path, JsonHelper.ToJson(this.data));
						AssetDatabase.Refresh();
					}
				}
				GUILayout.EndHorizontal();
			}
			GUILayout.EndVertical();
		}

		[RuntimeInitializeOnLoadMethod]
		private static void OnGameEnter()
		{
			if (File.Exists(path))
			{
				AlwaysLoadSceneWindowData data = JsonHelper.FromJson<AlwaysLoadSceneWindowData>(File.ReadAllText(path));
				if (string.IsNullOrEmpty(data.initSceneName) == false)
				{
					if (SceneManager.GetActiveScene().name != data.initSceneName)
					{
						SceneManager.LoadScene(data.initSceneName);
					}
				}
			}
		}
	}
}
