using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using ETModel;
using System;

namespace ETPlus
{

	public enum ServerCodeType
	{
		Other,
		AMHandler,
		AMRpcHandler,
		Entity,
		Component,
		Factory
	}

	public class ServerCodeWindowData
	{
		public string generatePath;
		public ServerCodeType codeType = ServerCodeType.Other;
		public string className;
		public AppType appType = AppType.AllServer;
		public string requestName;
		public string responseName;
	}

	public class ServerCodeWindow : EditorWindow
	{
		private const string savePath = @"./Assets/Res/Config/ServerCodeWindowData.txt";
		private ServerCodeWindowData data;

		[MenuItem("Tools/Plus/Server Code", priority = 2)]
		private static void ShowWindow()
		{
			ServerCodeWindow window = EditorWindow.GetWindow<ServerCodeWindow>() as ServerCodeWindow;
			window.minSize = new Vector2(600, 400);
			window.Show();
		}

		private void OnEnable()
		{
			titleContent = new GUIContent("Serverr Code");
			if (File.Exists(savePath))
			{
				data = JsonHelper.FromJson<ServerCodeWindowData>(File.ReadAllText(savePath));
			}
			else
			{
				data = new ServerCodeWindowData();
				data.generatePath = Application.dataPath.Replace("Unity/Assets", "Server/Hotfix/Module/Demo");
				Save();
			}
		}

		private void OnGUI()
		{
			GUILayout.BeginVertical("box", GUILayout.Width(600));
			{
				GUILayout.Space(5);

				// 标题
				GUILayout.BeginHorizontal();
				{
					GUILayout.FlexibleSpace();
					GUILayout.Label("服务端代码补全工具");
					GUILayout.FlexibleSpace();
				}
				GUILayout.EndHorizontal();

				GUILayout.Space(5);

				// 生成路径
				GUILayout.BeginHorizontal();
				{
					GUILayout.Label("生成路径:");
					string currentPath = GUILayout.TextField(data.generatePath, GUILayout.Width(500));
					if (currentPath != data.generatePath)
					{
						data.generatePath = currentPath;
						Save();
					}
				}
				GUILayout.EndHorizontal();

				GUILayout.Space(10);

				// 代码类型
				GUILayout.BeginHorizontal();
				{
					GUILayout.Label("代码类型:");
					ServerCodeType value = (ServerCodeType)EditorGUILayout.EnumPopup(data.codeType, GUILayout.Width(500));
					if (value != data.codeType)
					{
						data.codeType = value;
						Save();
					}
				}
				GUILayout.EndHorizontal();

				GUILayout.Space(10);

				// 类名
				GUILayout.BeginHorizontal();
				{
					GUILayout.Label("类名:");
					string value = GUILayout.TextField(data.className, GUILayout.Width(500));
					if (value != data.className)
					{
						data.className = value;
						Save();
					}
				}
				GUILayout.EndHorizontal();

				GUILayout.Space(10);

				// 应用类型
				GUILayout.BeginHorizontal();
				{
					GUILayout.Label("应用类型:");
					AppType value = (AppType)EditorGUILayout.EnumPopup(data.appType, GUILayout.Width(500));
					if (value != data.appType)
					{
						data.appType = value;
						Save();
					}
				}
				GUILayout.EndHorizontal();

				GUILayout.Space(10);

				// 请求消息
				GUILayout.BeginHorizontal();
				{
					GUILayout.Label("请求消息:");
					string value = GUILayout.TextField(data.requestName, GUILayout.Width(500));
					if (value != data.requestName)
					{
						data.requestName = value;
						Save();
					}
				}
				GUILayout.EndHorizontal();

				GUILayout.Space(10);

				// 响应消息
				GUILayout.BeginHorizontal();
				{
					GUILayout.Label("响应消息:");
					string value = GUILayout.TextField(data.responseName, GUILayout.Width(500));
					if (value != data.responseName)
					{
						data.responseName = value;
						Save();
					}
				}
				GUILayout.EndHorizontal();

				GUILayout.Space(10);

				if (GUILayout.Button("生成"))
				{
					Debug.Log($" == 测试: {Enum.GetName(typeof(ServerCodeType), data.codeType)} == ");
					switch(data.codeType)
					{
						case ServerCodeType.AMHandler:
							break;
						case ServerCodeType.AMRpcHandler:
							break;
						case ServerCodeType.Entity:
							break;
						case ServerCodeType.Component:
							break;
						case ServerCodeType.Factory:
							break;
						default:
							{
								// 普通
							}
							break;
					}
				}
			}
			GUILayout.EndVertical();
		}

		private void Save()
		{
			File.WriteAllText(savePath, JsonHelper.ToJson(data));
			AssetDatabase.Refresh();
		}
	}
}