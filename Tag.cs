using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace ToolBox.Tags
{
	[CreateAssetMenu(menuName = "ToolBox/Tag"), AssetSelector]
	public sealed class Tag : ScriptableObject
	{
		[ShowInInspector, ReadOnly] private HashSet<GameObject> entities = new HashSet<GameObject>();

		public void Add(GameObject entity) =>
			entities.Add(entity);

		public void Remove(GameObject entity) =>
			entities.Remove(entity);

		public bool HasEntity(GameObject entity) =>
			entities.Contains(entity);
	}
}

