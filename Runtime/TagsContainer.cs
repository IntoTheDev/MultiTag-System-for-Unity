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
		[SerializeField] private Tag[] _tags = null;

		public void Add(GameObject instance)
		{
			for (int i = 0; i < _tags.Length; i++)
				_tags[i].Add(instance);
		}

		public void Remove(GameObject instance)
		{
			for (int i = 0; i < _tags.Length; i++)
				_tags[i].Remove(instance);
		}

		public bool HasInstance(GameObject instance, bool allRequired) =>
			instance.HasTags(_tags, allRequired);
	}
}

