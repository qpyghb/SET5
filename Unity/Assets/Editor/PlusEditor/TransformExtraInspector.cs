using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;

namespace ETPlus
{

	// [CustomEditor(typeof(Transform))]
	public class TransformExtraInspector : Editor
	{
		private Editor editor;
		private Transform transform;
		private float scale;

		void OnEnable()
		{
			editor = CreateEditor(target, Assembly.GetAssembly(typeof(Editor)).GetType("UnityEditor.TransformInspector", true));
			transform = target as Transform;
			scale = transform.localScale.x;
		}

		public override void OnInspectorGUI()
		{
			editor.OnInspectorGUI();

			GUILayout.BeginHorizontal("box");
			{
				GUILayout.BeginHorizontal(GUILayout.Width(100));
				{
					GUILayout.Label("Scale");
					float currentScale = EditorGUILayout.FloatField(scale, GUILayout.Width(50));
					if (currentScale != scale)
					{
						scale = currentScale;
						transform.localScale = Vector3.one * scale;
					}
				}
				GUILayout.EndHorizontal();

				GUILayout.FlexibleSpace();

				GUILayout.BeginHorizontal();
				{
					if (GUILayout.Button("清空"))
					{
						transform.position = Vector3.zero;
						transform.rotation = Quaternion.identity;
						transform.localScale = Vector3.one;
						scale = 1f;
					}

					if (GUILayout.Button("1"))
					{
						RoundTransform(1);
					}

					if (GUILayout.Button(".5"))
					{
						RoundTransform(0.5f);
					}

					if (GUILayout.Button("0.1"))
					{
						RoundTransform(0.1f);
					}
				}
			}
			GUILayout.EndHorizontal();
		}

		private void RoundTransform(float precision)
		{
			transform.position = Round(transform.position, precision);
			transform.eulerAngles = Round(transform.eulerAngles, precision * 10);
			transform.localScale = Round(transform.localScale, precision);
		}

		private Vector3 Round(Vector3 value, float precision)
		{
			value /= precision;
			value.x = Mathf.RoundToInt(value.x);
			value.y = Mathf.RoundToInt(value.y);
			value.z = Mathf.RoundToInt(value.z);
			return value * precision;
		}

	}
}