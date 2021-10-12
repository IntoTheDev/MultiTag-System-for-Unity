#if UNITY_EDITOR
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace ToolBox.Tags.Editor
{
	[CustomEditor(typeof(Taggable))]
	internal class TaggableEditor : UnityEditor.Editor
	{
		private Tag[] _tags = null;

		private void OnEnable()
		{
			_tags = GetAllTags();
		}

		public override void OnInspectorGUI()
		{
			var taggable = target as Taggable;

			if (taggable == null)
				return;

			var instance = taggable.gameObject;
			int hash = instance.GetHashCode();
			
			foreach (var tag in _tags)
			{
				bool contains = taggable.Contains(tag);
				EditorGUILayout.BeginHorizontal();
				GUI.enabled = false;

				GUI.color = contains ? Color.green : Color.red;
				EditorGUILayout.ObjectField(tag, typeof(Tag), false);
				GUI.color = Color.white;
				
				GUI.enabled = !contains;
				if (GUILayout.Button("Add", EditorStyles.miniButtonLeft))
				{
					Undo.SetCurrentGroupName("Add tag");
					
					Undo.RecordObject(taggable, "Add gameObject to Tag");
					tag.Add(instance, hash);
					
					Undo.RecordObject(taggable, "Add Tag in the Inspector");
					taggable.Add(tag);
					
					Undo.CollapseUndoOperations(Undo.GetCurrentGroup());
					
					contains = true;
					
					EditorUtility.SetDirty(taggable);
				}
				
				GUI.enabled = contains;
				if (GUILayout.Button("Remove", EditorStyles.miniButtonLeft))
				{
					Undo.SetCurrentGroupName("Remove tag");
					
					Undo.RecordObject(taggable, "Remove gameObject from Tag");
					tag.Remove(instance, hash);
					
					Undo.RecordObject(taggable, "Remove Tag in the Inspector");
					taggable.Remove(tag);
					
					Undo.CollapseUndoOperations(Undo.GetCurrentGroup());
					
					EditorUtility.SetDirty(taggable);
				}

				GUI.enabled = true;
				EditorGUILayout.EndHorizontal();
			}
		}

		private static Tag[] GetAllTags()
		{
			var paths = AssetDatabase.FindAssets("t:Tag").Select(AssetDatabase.GUIDToAssetPath);
			return paths.Select(AssetDatabase.LoadAssetAtPath<Tag>).ToArray();
		}
	}
}
#endif