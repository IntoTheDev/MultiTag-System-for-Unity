using Sirenix.OdinInspector;
using UnityEngine;

namespace ToolBox.Tags
{
	[DisallowMultipleComponent, DefaultExecutionOrder(-95)]
	public sealed class Taggable : MonoBehaviour
	{
		[SerializeField, Required] private Tag[] _tags = default;

		private int _hash = 0;

		private void Awake() =>
			_hash = gameObject.GetHashCode();

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
	}
}

