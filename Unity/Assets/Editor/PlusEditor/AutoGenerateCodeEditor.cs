using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Text.RegularExpressions;
using System.IO;

namespace ETPlus
{
	public class AutoGenerateCodeEditor : UnityEditor.AssetModificationProcessor
	{
		private enum ScriptType
		{
			Other,
			Component,
			Event,
		}

		/// <summary>
		/// 即将创建Asset时
		/// </summary>
		/// <param name="assetName">创建的Asset名字</param>
		private static void OnWillCreateAsset(string path)
		{
			path = path.Replace(".meta", "");

			// 如果不是 CSharp
			if (path.EndsWith(".cs") == false)
			{
				return;
			}

			// 排除导入的脚本 和 获取类名
			string text = File.ReadAllText(path);
			string className = GetClassName(text);
			if (className == null)
			{
				return;
			}

			// 获取脚本类型， 这决定生成的脚本样式
			ScriptType scriptType = GetScriptType(className);
			if (scriptType == ScriptType.Other)
			{
				return;
			}

			string scriptNamespace = "";
			string eachNamespace = "";
			if (path.StartsWith("Assets/Hotfix/"))
			{
				scriptNamespace = "ETHotfix";
				eachNamespace = "ETModel";
			}
			else if (path.StartsWith("Assets/Model/"))
			{
				scriptNamespace = "ETModel";
				eachNamespace = "ETHotfix";
			}
			else
			{
				return;
			}

			// 自定义脚本
			using (FileStream fs = new FileStream(path, FileMode.Truncate, FileAccess.ReadWrite, FileShare.ReadWrite))
			{
				using (StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8))
				{
					// 起头
					if (scriptType == ScriptType.Component)
					{
						sw.Write(
$"using {eachNamespace};" +
@"
using UnityEngine;

namespace " + scriptNamespace +
@"
{
	[ObjectSystem]
" +
		$"	public class {className}AwakeSystem : AwakeSystem<{className}>" +
		@"
	{
" +
		$"		public override void Awake({className} self)" +
		@"
		{
			self.Awake();
		}
	}

	[ObjectSystem]
" +
		$"	public class {className}StartSystem : StartSystem<{className}>" +
		@"
	{
" +
		$"		public override void Start({className} self)" +
		@"
		{
			self.Start();
		}
	}

	[ObjectSystem]
" +
		$"	public class {className}UpdateSystem : UpdateSystem<{className}>" +
		@"
	{
" +
		$"		public override void Update({className} self)" +
		@"
		{
			self.Update();
		}
	}

	" +
		$"public class {className}: Component" +
		@"
	{
		public void Awake()
		{

		}

		public void Start()
		{

		}

		public void Update()
		{

		}
	}
}
");
					}
					else if (scriptType == ScriptType.Event)
					{
						string eventName = className.Replace("Event", "");

						// 添加EventIdType
						AddEventIdType(eventName, scriptNamespace);

						// 生成事件脚本
						sw.WriteLine($"using {eachNamespace};");
						sw.WriteLine();
						sw.WriteLine($"namespace {scriptNamespace}");
						sw.WriteLine("{");
						sw.WriteLine($"	[Event(EventIdType.{eventName})]");
						sw.WriteLine($"	public class {className}: AEvent");
						sw.Write(
@"	{
		public override void Run()
		{

		}
	}
}
"
							);
					}
				}
			}

			AssetDatabase.Refresh();
		}

		/// <summary>
		/// 添加一个EventIdType
		/// </summary>
		/// <param name="eventName">事件名</param>
		private static void AddEventIdType(string eventName, string scriptNamespace)
		{
			string path = "Assets/Hotfix/Base/Event/EventIdType.cs";
			if (scriptNamespace == "ETModel")
			{
				path = "Assets/Model/Base/Event/EventIdType.cs";
			}
			string text = File.ReadAllText(path);

			// 使用正则匹配到所有EventName
			string pattern = "public const string ([A-Za-z0-9_]+) = \"([A-Za-z0-9_]+)\"";
			MatchCollection matchs = Regex.Matches(text, pattern);

			// 添加一个EventIdType
			using (FileStream fs = new FileStream(path, FileMode.Truncate, FileAccess.ReadWrite, FileShare.ReadWrite))
			{
				using (StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8))
				{
					sw.Write(
$"namespace {scriptNamespace}" +
@"
{
	public static class EventIdType
	{
");
					// 把原来的写上
					for (int i = 0; i < matchs.Count; i++)
					{
						string matchName = matchs[i].Groups[1].Value;
						if (matchName == eventName)
						{
							Debug.LogError($"已经存在事件:{eventName}, 请检查代码.");
							continue;
						}
						sw.WriteLine($"		public const string {matchName} = \"{matchName}\";");
					}
					sw.WriteLine($"		public const string {eventName} = \"{eventName}\";");
					sw.Write(
@"	}
}
");
				}
			}
		}

		/// <summary>
		/// 获取脚本类型
		/// </summary>
		/// <param name="className">类名</param>
		/// <returns>脚本类型</returns>
		private static ScriptType GetScriptType(string className)
		{
			if (className.EndsWith("Component"))
			{
				return ScriptType.Component;
			}
			else if (className.EndsWith("Event"))
			{
				return ScriptType.Event;
			}
			else
			{
				return ScriptType.Other;
			}
		}

		/// <summary>
		/// 获取生成 New Monobehaviour 中的类名
		/// </summary>
		private static string GetClassName(string text)
		{
			// 判断是否是原生的MonoBehaviour
			if (!text.Contains("// Start is called before the first frame update") && !text.Contains("// Update is called once per frame"))
			{
				return null;
			}

			// 正则匹配
			string pattern = "public class ([A-Za-z0-9_]+)\\s:\\sMonoBehaviour";
			var match = Regex.Match(text, pattern);
			if (match.Success)
			{
				return match.Groups[1].Value;
			}

			return null;
		}
	}
}
