using System;
using System.Reflection;
using UnityEditor;
using UnityEditor.ShortcutManagement;
using UnityEngine;

namespace CustomEditor
{
    public class ReferencesInspectorEditor : EditorWindow
    {
		private static Type _referencesInspector;
		private static Type _inspector;

		private SerializedObject _currentSerializedComp;
		private Vector2 _scroll;
		private const BindingFlags _flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

		[MenuItem("Extensions/Windows/References Inspector #q", priority = 1)]
		public static ReferencesInspectorEditor ShowEditor()
		{
			ReferencesInspectorEditor window = GetWindow<ReferencesInspectorEditor>(false, "References Inspector", true);
			window.position = new Rect(1648f, 73.6f, 399f, 998f);
			return window;
		}

		[Shortcut("ReferencesInspector", KeyCode.X, ShortcutModifiers.Shift)]
		public static void FocusReferencesInspector()
		{
			if (_referencesInspector == null) _referencesInspector = typeof(ReferencesInspectorEditor);
			FocusWindowIfItsOpen(_referencesInspector);
		}

		[Shortcut("Inspector", KeyCode.Z, ShortcutModifiers.Shift)]
		public static void FocusInspector()
		{
			if(_inspector == null) _inspector = AppDomain.CurrentDomain.Load("UnityEditor").GetType("UnityEditor.InspectorWindow");
			FocusWindowIfItsOpen(_inspector);
		}

		public void OnEnable()
		{
			Selection.selectionChanged += Repaint;
		}

		public void OnDisable()
		{
			Selection.selectionChanged -= Repaint;
		}

		private void OnGUI()
		{
			_scroll = EditorGUILayout.BeginScrollView(_scroll);

			foreach (GameObject obj in Selection.gameObjects)
			{
				MonoBehaviour[] components = obj.GetComponents<MonoBehaviour>();
				if (components.Length == 0) continue;

				DisplayHeader(obj.name);
				foreach (MonoBehaviour comp in components)
				{
					_currentSerializedComp = new SerializedObject(comp);
					_currentSerializedComp.Update();

					EditorGUILayout.Space(10f);
					DisplayComponent(comp);

					if (GUI.changed) EditorUtility.SetDirty(comp);
					_currentSerializedComp.ApplyModifiedProperties();
				}
			}

			EditorGUILayout.EndScrollView();
		}

		private void DisplayComponent(MonoBehaviour component)
		{
			DisplayHeader(component.GetType().Name);

			var fields = component.GetType().GetFields(_flags);

			EditorGUILayout.BeginVertical("box");

			foreach(FieldInfo field in fields)
			{
				if (field.IsPrivate && field.GetCustomAttributes(typeof(SerializeField), false).Length == 0) continue;
				DisplayField(field);
			}

			EditorGUILayout.EndVertical();
		}

		private void DisplayField(MemberInfo field)
		{
			EditorGUILayout.BeginHorizontal();

			SerializedProperty property = _currentSerializedComp.FindProperty(field.Name);
			EditorGUILayout.PropertyField(property);

			EditorGUILayout.EndHorizontal();
		}

		private static void DisplayHeader(string text)
		{
			EditorGUILayout.LabelField(". . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . .");
			EditorGUILayout.Space(10f);
			EditorGUILayout.LabelField(text);
		}
    }
}