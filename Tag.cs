using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace ToolBox.Tags
{
	[CreateAssetMenu(menuName = "ToolBox/Tag"), AssetSelector]
	public sealed class Tag : ScriptableObject
	{
		[ShowInInspector, ReadOnly] private HashSet<int> _entities = new HashSet<int>();

		public void Add(int entity) =>
			_entities.Add(entity);

		public void Remove(int entity) =>
			_entities.Remove(entity);

		public bool HasEntity(int entity) =>
			_entities.Contains(entity);
	}
}

