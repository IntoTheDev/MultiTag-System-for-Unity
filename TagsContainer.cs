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

		public bool HasEntity(GameObject entity, bool allRequired) =>
			entity.HasTags(_tags, allRequired);
	}
}

