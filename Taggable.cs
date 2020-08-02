using Sirenix.OdinInspector;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace ToolBox.Tags
{
	[DisallowMultipleComponent]
	public sealed class Taggable : MonoBehaviour
	{
		[SerializeField, Required, AssetList] private Tag[] _tags = default;

		private Tag[] _all = null;
		private int _hash = 0;

		private void Awake()
		{
#if UNITY_EDITOR
			_all = Resources.FindObjectsOfTypeAll<Tag>();

			if (_tags == null)
				_tags = new Tag[0];
#endif

			_hash = gameObject.GetHashCode();
		}

		private void OnEnable()
		{
			for (int i = 0; i < _tags.Length; i++)
				_tags[i].Add(_hash);
		}

		private void OnDisable()
		{
			for (int i = 0; i < _tags.Length; i++)
				_tags[i].Remove(_hash);
		}

#if UNITY_EDITOR
		public void Add(Tag tag)
		{
			if (!ArrayUtility.Contains(_tags, tag))
				ArrayUtility.Add(ref _tags, tag);
		}

		public void Remove(Tag tag)
		{
			if (ArrayUtility.Contains(_tags, tag))
				ArrayUtility.Remove(ref _tags, tag);
		}

		private void OnValidate()
		{
			if (!Application.isPlaying || _all == null)
				return;

			var obj = gameObject;

			foreach (var tag in _all)
			{
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
#endif
	}
}

