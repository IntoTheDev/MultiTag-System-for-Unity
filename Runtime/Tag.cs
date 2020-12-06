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
#if ODIN_INSPECTOR
		[ShowInInspector, ReadOnly]
#endif
		private HashSet<int> _entities = new HashSet<int>();

		public void Add(int entity) =>
			_entities.Add(entity);

		public void Remove(int entity) =>
			_entities.Remove(entity);

		public bool HasEntity(int entity) =>
			_entities.Contains(entity);
	}
}

