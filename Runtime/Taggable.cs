#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace ToolBox.Tags
{
	[DisallowMultipleComponent, DefaultExecutionOrder(-9000), ExecuteInEditMode]
	internal sealed class Taggable : MonoBehaviour
	{
#if ODIN_INSPECTOR
		[Required, AssetList]
#endif
		[SerializeField] private Tag[] _tags = Array.Empty<Tag>();

		private void Awake()
		{
			gameObject.AddTags(_tags);
		}

		private void OnDestroy()
		{
			gameObject.RemoveTags(_tags);
		}

		#if UNITY_EDITOR
		internal void Add(Tag tag)
		{
			ArrayUtility.Add(ref _tags, tag);
		}

		internal void Remove(Tag tag)
		{
			ArrayUtility.Remove(ref _tags, tag);
		}

		internal bool Contains(Tag tag)
		{
			return ArrayUtility.Contains(_tags, tag);
		}
		#endif
	}
}
