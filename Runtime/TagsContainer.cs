#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
using UnityEngine;

namespace ToolBox.Tags
{
	[CreateAssetMenu(menuName = "ToolBox/MultiTags/Tags Container")]
#if ODIN_INSPECTOR
	[AssetSelector, Required]
#endif
	public sealed class TagsContainer : ScriptableObject
	{
		[SerializeField] private Tag[] _tags = new Tag[0];

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

		internal bool HasInstance(GameObject instance, bool allRequired) =>
			instance.HasTags(_tags, allRequired);
	}
}
