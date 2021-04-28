#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
using System.Collections.Generic;
using UnityEngine;

namespace ToolBox.Tags
{
	[CreateAssetMenu(menuName = "ToolBox/MultiTags/Tag")]
#if ODIN_INSPECTOR
	[AssetSelector, Required]
#endif
	public sealed class Tag : ScriptableObject
	{
		private readonly HashSet<int> _instancesHash = new HashSet<int>();
		private readonly List<GameObject> _instances = new List<GameObject>(128);
		private readonly List<GameObject> _temp = new List<GameObject>(128);

		public void Add(GameObject instance)
		{
			int hash = instance.GetHashCode();

			if (!_instancesHash.Contains(hash))
			{
				_instances.Add(instance);
				_instancesHash.Add(hash);
			}
		}

		public void Remove(GameObject instance)
		{
			int hash = instance.GetHashCode();

			if (_instancesHash.Contains(hash))
			{
				_instances.Remove(instance);
				_instancesHash.Remove(hash);
			}
		}

		public bool HasInstance(int instanceHash) =>
			_instancesHash.Contains(instanceHash);

		public IReadOnlyList<GameObject> GetInstances()
		{
			_temp.Clear();

			for (int i = _instances.Count - 1; i >= 0; i--)
			{
				var instance = _instances[i];

				if (instance == null)
				{
					_instances.RemoveAt(i);
					continue;
				}

				if (instance.activeInHierarchy)
					_temp.Add(instance);
			}

			return _temp.AsReadOnly();
		}
	}
}

