using Sirenix.OdinInspector;
using UnityEngine;

namespace ToolBox.Tags
{
	[CreateAssetMenu(menuName = "ToolBox/Tagging/Tags Container"), AssetSelector]
	public sealed class TagsContainer : ScriptableObject
	{
		[SerializeField] private Tag[] _tags = null;

		public bool HasEntity(GameObject entity, bool allRequired) =>
			entity.HasTags(_tags, allRequired);
	}
}

