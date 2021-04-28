#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
using UnityEngine;

namespace ToolBox.Tags
{
	[DisallowMultipleComponent, DefaultExecutionOrder(-9000)]
	internal sealed class Taggable : MonoBehaviour
	{
#if ODIN_INSPECTOR
		[Required, AssetList]
#endif
		[SerializeField] private Tag[] _tags = new Tag[0];

		private void Awake() =>
			gameObject.AddTags(_tags);

		private void OnDestroy() =>
			gameObject.RemoveTags(_tags);
	}
}
