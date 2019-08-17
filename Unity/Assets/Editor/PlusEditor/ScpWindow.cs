using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Diagnostics;
using ETEditor;
using Debug = UnityEngine.Debug;
using System.IO;
using System;
using ETModel;

namespace ETPlus
{
	public class ScpWindow : EditorWindow
	{
		private static Vector2 scrollPos = Vector2.zero;
		private static string serverIP = "119.23.241.65";
		private static string username = "root";
		private static string serverBundlePath = "/var/www/html/ET";
		private static PlatformType platformType = PlatformType.None;

		private ScpWindow()
		{
			this.titleContent = new GUIContent("Scp Window");
		}

		[MenuItem("Tools/Plus/Scp Window #s", priority = 0)]
		private static void ShowWindow ()
		{
			ScpWindow scpWindow = EditorWindow.GetWindow<ScpWindow>() as ScpWindow;
			scpWindow.minSize = new Vector2(400, 250);
			scpWindow.Show();
		}

		private void OnEnable()
		{
			
		}

		private void OnGUI()
		{
			// 滚动条
			scrollPos = GUILayout.BeginScrollView(scrollPos, GUILayout.Width(position.width), GUILayout.Height(position.height));
			{
				// 内容
				GUILayout.BeginVertical("box", GUILayout.Width(400), GUILayout.Height(250));
				{
					// IP地址输入框
					GUILayout.BeginHorizontal();
					{
						GUILayout.Label("服务器ip:");
						serverIP = GUILayout.TextField(serverIP, GUILayout.Width(250));
					}
					GUILayout.EndHorizontal();

					// 用户名输入框
					GUILayout.BeginHorizontal();
					{
						GUILayout.Label("username:");
						username = GUILayout.TextField(username, GUILayout.Width(250));
					}
					GUILayout.EndHorizontal();

					GUILayout.Space(20);

					// 同步热更资源
					GUILayout.BeginVertical("box", GUILayout.Width(400), GUILayout.Height(50));
					{
						// 服务器资源地址
						GUILayout.BeginHorizontal();
						{
							GUILayout.Label("服务器资源地址:");
							serverBundlePath = GUILayout.TextField(serverBundlePath, GUILayout.Width(250));
						}
						GUILayout.EndHorizontal();

						GUILayout.Space(10);

						// 平台类型
						platformType = (PlatformType)EditorGUILayout.EnumPopup(platformType);

						GUILayout.Space(10);

						if (GUILayout.Button("同步资源"))
						{
							if (platformType == PlatformType.None)
							{
								Debug.LogError("请选择平台, 当前为: None");
							}
							else
							{
								// Release下的热更目录
								string platformName = Enum.GetName(typeof(PlatformType), platformType);
								string localBundlePath = Application.dataPath.Replace("Unity/Assets", $"Release/{platformName}");
								if (Directory.Exists(localBundlePath) == false)
								{
									Debug.LogError($"不存在路径: {localBundlePath}, 请检查是否打包此平台的AssetBundle");
									return;
								}

								string arguments = $"-r {localBundlePath} {username}@{serverIP}:{serverBundlePath}";

								Debug.Log($"同步服务器资源, 命令: scp {arguments}");
								ProcessHelper.Run("scp", arguments);
							}
						}
					}
					GUILayout.EndVertical();
				}
				GUILayout.EndVertical();
			}
			GUILayout.EndScrollView();
		}
	}
}