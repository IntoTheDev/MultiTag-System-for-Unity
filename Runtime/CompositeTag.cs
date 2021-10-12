#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ToolBox.Tags
{
	[CreateAssetMenu(menuName = "ToolBox/Tags/Composite Tag")]
#if ODIN_INSPECTOR
	[AssetSelector, Required]
#endif
	public sealed class CompositeTag : ScriptableObject
	{
		[SerializeField] private Tag[] _tags = Array.Empty<Tag>();

		internal IEnumerable<Tag> Tags => _tags;

		internal void Add(GameObject instance, int hash)
		{
			for (int i = 0; i < _tags.Length; i++)
				_tags[i].Add(instance, hash);
		}

		internal void Remove(GameObject instance, int hash)
		{
			for (int i = 0; i < _tags.Length; i++)
				_tags[i].Remove(instance, hash);
		}

		internal bool HasInstance(GameObject instance, bool allRequired)
		{
			return instance.HasTags(_tags, allRequired);
		}
	}
}
