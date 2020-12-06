#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace ToolBox.Tags
{
	[DisallowMultipleComponent, DefaultExecutionOrder(-9000), ExecuteInEditMode]
	public sealed class Taggable : MonoBehaviour
	{
#if ODIN_INSPECTOR
		[Required, AssetList]
#endif
		[SerializeField] private Tag[] _tags = default;

		private static Tag[] _all = null;
		private int _hash = 0;

		private void Awake()
		{
#if UNITY_EDITOR
			SetupEditorData();
#endif

			_hash = gameObject.GetHashCode();
			AddAll();
		}

		private void OnDestroy() =>
			RemoveAll();

		private void AddAll()
		{
			for (int i = 0; i < _tags.Length; i++)
				_tags[i].Add(_hash);
		}

		private void RemoveAll()
		{
			for (int i = 0; i < _tags.Length; i++)
				_tags[i].Remove(_hash);
		}

#if UNITY_EDITOR
		public void AddTagInEditor(Tag tag)
		{
			if (!ArrayUtility.Contains(_tags, tag))
				ArrayUtility.Add(ref _tags, tag);
		}

		public void RemoveTagInEditor(Tag tag)
		{
			if (ArrayUtility.Contains(_tags, tag))
				ArrayUtility.Remove(ref _tags, tag);
		}

		// Handle Inspector Changes
		private void OnValidate()
		{
			SetupEditorData();
			var obj = gameObject;
			AddAll();

			for (int i = 0; i < _all.Length; i++)
			{
				var tag = _all[i];

				if (ArrayUtility.Contains(_tags, tag))
				{
					if (!obj.HasTag(tag))
						obj.AddTag(tag);
				}
				else
				{
					if (obj.HasTag(tag))
						obj.RemoveTag(tag);
				}
			}
		}

		private void SetupEditorData()
		{
			if (_all == null)
				_all = Resources.FindObjectsOfTypeAll<Tag>();

			if (_tags == null)
			{
				_tags = new Tag[0];
			}
			else
			{
				for (int i = _tags.Length - 1; i >= 0; i--)
				{
					var tag = _tags[i];

					if (tag == null)
						ArrayUtility.RemoveAt(ref _tags, i);
				}
			}

			if (_hash == 0)
				_hash = gameObject.GetHashCode();
		}
#endif
	}
}

