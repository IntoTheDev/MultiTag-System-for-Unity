#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
using UnityEngine;

namespace ToolBox.Tags
{
	[DisallowMultipleComponent, DefaultExecutionOrder(-9000)]
	public sealed class Taggable : MonoBehaviour
	{
#if ODIN_INSPECTOR
		[Required, AssetList]
#endif
		[SerializeField] private Tag[] _tags = default;

		private GameObject _instance = null;

		private void Awake()
		{
			_instance = gameObject;
			_instance.AddTags(_tags);
		}

		private void OnDestroy() =>
			_instance.RemoveTags(_tags);
	}
}

