using Sirenix.OdinInspector;
using UnityEngine;

namespace ToolBox.Tags
{
	[DisallowMultipleComponent]
	public sealed class Taggable : MonoBehaviour
	{
		[SerializeField, Required] private Tag[] tags = default;

		private GameObject cachedObject = null;

		private void Awake() =>
			cachedObject = gameObject;

		private void OnEnable()
		{
			for (int i = 0; i < tags.Length; i++)
				tags[i].Add(cachedObject);
		}

		private void OnDisable()
		{
			for (int i = 0; i < tags.Length; i++)
				tags[i].Remove(cachedObject);
		}
	}
}

