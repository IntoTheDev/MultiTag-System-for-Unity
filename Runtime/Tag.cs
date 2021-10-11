#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
using System.Collections.Generic;
using UnityEngine;

namespace ToolBox.Tags
{
	[CreateAssetMenu(menuName = "ToolBox/Tags/Tag")]
#if ODIN_INSPECTOR
	[AssetSelector, Required]
#endif
	public sealed class Tag : ScriptableObject
	{
		private readonly HashSet<int> _instancesHash = new HashSet<int>();
		private readonly List<GameObject> _instances = new List<GameObject>(128);

		internal void Add(GameObject instance, int hash)
		{
			if (_instancesHash.Contains(hash))
				return;
			
			_instances.Add(instance);
			_instancesHash.Add(hash);
		}

		internal void Remove(GameObject instance, int hash)
		{
			if (!_instancesHash.Contains(hash))
				return;
			
			_instances.Remove(instance);
			_instancesHash.Remove(hash);
		}

		internal bool HasInstance(int hash)
		{
			return _instancesHash.Contains(hash);
		}

		public IEnumerable<GameObject> GetInstances()
		{
			int instancesCount = _instances.Count - 1;
			for (int i = instancesCount; i >= 0; i--)
			{
				var instance = _instances[i];
				
				if (instance == null)
				{
					_instances.RemoveAt(i);
					continue;
				}

				yield return instance;
			}
		}
	}
}

