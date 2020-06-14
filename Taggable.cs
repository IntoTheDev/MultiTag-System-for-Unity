using Sirenix.OdinInspector;
using UnityEngine;

namespace ToolBox.Tags
{
	[DisallowMultipleComponent]
	public sealed class Taggable : MonoBehaviour
	{
		[SerializeField, Required] private Tag[] _tags = default;

		private GameObject _gameObject = null;

		private void Awake() =>
			_gameObject = gameObject;

		private void OnEnable()
		{
			for (int i = 0; i < _tags.Length; i++)
				_tags[i].Add(_gameObject);
		}

		private void OnDisable()
		{
			for (int i = 0; i < _tags.Length; i++)
				_tags[i].Remove(_gameObject);
		}
	}
}

